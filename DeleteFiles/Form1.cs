using System;
using System.Linq;
using System.Windows.Forms;
using DeleteFiles.Core;

namespace DeleteFiles
{
    public partial class Form1 : Form
    {
        private Deleter deleter;

        public Form1()
        {
            this.InitializeComponent();
            this.InitComponents();
        }

        private void InitComponents()
        {
            this.cBoxExtensions.SelectedItem = ".torrent";
            this.cBoxPreparedFiles.Visible = false;
            this.btnRemoveFile.Visible = false;
            this.lblPreparedFilesLabel.Visible = false;
            this.btnDelete.Visible = false;
            this.lblStatus.Visible = false;
            this.tboxError.Visible = false;
            this.deleter = null;
            this.checkBoxRecursiveFolder.Checked = false;
            this.tBoxSelectedFolder.Text = string.Empty;
            this.cBoxPreparedFiles.Items.Clear();
        }

        private void SelectFolderOnClick(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {
                this.tBoxSelectedFolder.Text = folder.SelectedPath;
            }
        }

        private void GetFilesForDelete(object sender, EventArgs e)
        {
            this.ClearLastActivity();

            if (string.IsNullOrWhiteSpace(this.tBoxSelectedFolder.Text))
            {
                MessageBox.Show("Must select a folder !!!");
                return;
            }

            this.deleter = new Deleter(this.cBoxExtensions.SelectedItem.ToString());

            var preparedFiles = deleter.GetFilesForDelete(this.tBoxSelectedFolder.Text, this.checkBoxRecursiveFolder.Checked);

            if (!preparedFiles.Any())
            {
                MessageBox.Show("No such file!");
                return;
            }

            this.cBoxPreparedFiles.MaxDropDownItems = preparedFiles.Count();
            this.cBoxPreparedFiles.Items.AddRange(preparedFiles.ToArray());

            this.cBoxPreparedFiles.SelectedIndex = 0;

            this.ShowPreparedFilesForDelete();
        }

        private void ShowPreparedFilesForDelete()
        {
            this.cBoxPreparedFiles.Visible = true;
            this.btnRemoveFile.Visible = true;
            this.lblPreparedFilesLabel.Visible = true;
            this.btnDelete.Visible = true;
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
            bool isDeleted = this.deleter.DeleteFileFromList(selectedFile.ToString());

            if (isDeleted)
            {
                this.cBoxPreparedFiles.Items.Remove(selectedFile);

                if (this.cBoxPreparedFiles.Items.Count > 0)
                {
                    this.cBoxPreparedFiles.SelectedIndex = 0;
                }

                MessageBox.Show($"File is deleted from list.\n\r{selectedFile}");
            }
            else
            {
                MessageBox.Show($"File do not exists in the list.");
            }
        }

        private void DeleteFiles(object sender, EventArgs e)
        {
            int numberOfDeletedFiles = this.deleter.DeleteFiles();

            this.cBoxPreparedFiles.Items.Clear();

            this.PrintCountOfDeletedFiles(numberOfDeletedFiles);

            this.CheckForErrors();
        }

        private void CheckForErrors()
        {
            var logs = this.deleter.GetLogs;

            if (logs != null && logs.Length > 0)
            {
                int count = 1;
                foreach (var error in logs)
                {
                    this.tboxError.Text += count + "." + error + Environment.NewLine;
                }

                this.tboxError.Visible = true;
            }
            else
            {
                this.InitComponents();
                this.lblStatus.Visible = true;
            }
        }

        private void PrintCountOfDeletedFiles(int numberOfDeletedFiles)
        {
            string infoText = " files were deleted.";
            this.lblStatus.Visible = true;

            if (numberOfDeletedFiles == 1)
            {
                infoText = " file was deleted.";
            }

            this.lblStatus.Text = numberOfDeletedFiles + infoText;
        }
    }
}
