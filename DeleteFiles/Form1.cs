namespace DeleteFiles
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using DeleteFiles.Globals;
    using DeleteFiles.Interfaces;

    public partial class Form1 : Form
    {
        private IDeleter deleter;
        private IDeleterRepo repo;

        private int page;

        public Form1()
        {
            this.InitializeComponent();
            this.InitDependencies();
            this.InitComponents();
        }

        private void InitDependencies()
        {
            var currentClasses = Assembly.GetExecutingAssembly().GetTypes().Where(c => c.Name == this.Name);

            foreach (var cl in currentClasses)
            {
                var fields = cl.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(f=> f.FieldType.IsInterface && f.IsPrivate);

                foreach (var fieldInfo in fields)
                {
                    if (fieldInfo.FieldType.Namespace.StartsWith(this.GetType().Namespace))
                    {
                        var classWithThisInterface =
                            Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .Where(t => t.IsClass)
                                .FirstOrDefault(c => c.GetInterfaces().Contains(fieldInfo.FieldType));

                        if (classWithThisInterface == null)
                        {
                            continue;
                        }

                        var instance = Activator.CreateInstance(classWithThisInterface, true);
                        
                        fieldInfo.SetValue(this, instance);
                    }
                }
            }

            
        }

        private void InitComponents()
        {
            this.cBoxExtensions.SelectedItem = GlobalVar.DefaultFileExtension;
            this.cBoxPreparedFiles.Visible = false;
            this.btnRemoveFile.Visible = false;
            this.lblPreparedFilesLabel.Visible = false;
            this.btnDelete.Visible = false;
            this.lblStatus.Visible = false;
            this.tboxError.Visible = false;
            this.checkBoxRecursiveFolder.Checked = false;
            this.tBoxSelectedFolder.Text = string.Empty;
            this.cBoxPreparedFiles.Items.Clear();
            
            this.cBoxPage.Visible = false;
            this.lblPage.Visible = false;

            this.ClearLastActivity();
        }

        private void SelectFolderOnClick(object sender, EventArgs e)
        {
            //int numOfFiles = 110;
            //string testPath = @"D:\Downloads\test";
            //string nameOfFile = "test";
            //this.GenerateTxtFiles(numOfFiles, nameOfFile, testPath);

            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {
                this.tBoxSelectedFolder.Text = folder.SelectedPath;
            }
        }

        private void GenerateTxtFiles(int numOfFiles, string name, string testPath)
        {
            for (int i = 0; i < numOfFiles; i++)
            {
                string currentIndex = i < 10 ? $"0{i}" : i.ToString();
                string fileName = $"{name}-{currentIndex}.txt";
                File.Create(Path.Combine(testPath, fileName));
            }
        }

        private void GetFilesForDelete(object sender, EventArgs e)
        {
            //this.ClearLastActivity();

            if (string.IsNullOrWhiteSpace(this.tBoxSelectedFolder.Text))
            {
                MessageBox.Show(GlobalVar.SelectFolder);
                return;
            }

            var folderPath = this.tBoxSelectedFolder.Text;
            var recursiveSearch = this.checkBoxRecursiveFolder.Checked;
            var extension = this.cBoxExtensions.SelectedItem.ToString();

            var collection = this.deleter.GetFilesForDelete(folderPath, recursiveSearch, extension);

            this.repo.AddAll(collection);

            if (!this.repo.GetAllFiles().Any())
            {
                MessageBox.Show(GlobalVar.NoSuchFile);
                return;
            }
            
            this.page = GlobalVar.StartPage;
            
            this.SetNumberOfPages(this.repo.GetPages(GlobalVar.MaxResultPerPage));

            this.ShowPreparedFilesForDelete();
        }

        private void ShowSelectedPage()
        {
            this.cBoxPage.Visible = true;
            this.lblPage.Visible = true;

            this.cBoxPreparedFiles.Items.Clear();

            this.cBoxPreparedFiles.Items.AddRange(this.repo.ShowFilesPerPage(this.page, GlobalVar.MaxResultPerPage));

            this.cBoxPreparedFiles.SelectedIndex = GlobalVar.FirstIndex;
        }

        private void SetNumberOfPages(int numOfPages)
        {
            this.cBoxPage.Items.Clear();

            for (int i = 1; i <= numOfPages; i++)
            {
                this.cBoxPage.Items.Add(i);
            }

            this.cBoxPage.SelectedIndex = GlobalVar.FirstIndex;
        }

        private void ShowPreparedFilesForDelete()
        {
            this.cBoxPreparedFiles.Visible = true;
            this.btnRemoveFile.Visible = true;
            this.lblPreparedFilesLabel.Visible = true;
            this.btnDelete.Visible = true;
            this.page = GlobalVar.StartPage;
        }

        private void ClearLastActivity()
        {
            this.lblStatus.Text = string.Empty;
            this.lblStatus.Visible = false;
            this.tboxError.Visible = false;
            this.tboxError.Text = string.Empty;
        }

        private void RemoveFileFromList(object sender, EventArgs e)
        {
            var selectedFile = this.cBoxPreparedFiles.SelectedItem;
            bool isDeleted = this.repo.Remove(selectedFile.ToString());

            if (isDeleted)
            {
                this.ShowSelectedPage();

                this.SetNumberOfPages(this.repo.GetPages(GlobalVar.MaxResultPerPage));

                MessageBox.Show(string.Format(GlobalVar.FileIsDeleted, selectedFile));
            }
            else
            {
                MessageBox.Show(GlobalVar.FileDoesNotExists);
            }
        }

        private void DeleteFiles(object sender, EventArgs e)
        {
            int numberOfDeletedFiles = this.deleter.DeleteFiles(this.repo.GetAllFiles());

            this.cBoxPreparedFiles.Items.Clear();

            this.repo.Clear();

            this.PrintCountOfDeletedFiles(numberOfDeletedFiles);

            this.CheckForErrorsAndRestart();
        }

        private void CheckForErrorsAndRestart()
        {
            var logs = this.deleter.GetLogs;

            if (logs != null && logs.Length > 0)
            {
                int count = 1;
                foreach (var error in logs)
                {
                    this.tboxError.Text += string.Format(GlobalVar.ErrorMessage, count, error, Environment.NewLine);
                }

                this.tboxError.Visible = true;
            }
            else
            {
                this.lblStatus.Visible = true;
            }

            this.btnDelete.Visible = false;
        }

        private void PrintCountOfDeletedFiles(int numberOfDeletedFiles)
        {
            this.lblStatus.Visible = true;

            if (numberOfDeletedFiles == 1)
            {
                this.lblStatus.Text = string.Format(GlobalVar.FileDeletedInfoText, numberOfDeletedFiles);
            }
            else
            {
                this.lblStatus.Text = string.Format(GlobalVar.FilesDeletedInfoText, numberOfDeletedFiles);
            }
            
        }

        private void OnPageSelect(object sender, EventArgs e)
        {
            this.page = (int)this.cBoxPage.SelectedItem;
            this.ShowSelectedPage();
            // this.cBoxPage.SelectedIndexChanged += this.OnPageSelect;
        }

        private void OnClickResetForm(object sender, EventArgs e)
        {
            this.InitComponents();
        }
    }
}
