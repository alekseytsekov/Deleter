namespace DeleteFiles
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSelectFolder = new System.Windows.Forms.Label();
            this.tBoxSelectedFolder = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.cBoxExtensions = new System.Windows.Forms.ComboBox();
            this.lblExtensionLabel = new System.Windows.Forms.Label();
            this.checkBoxRecursiveFolder = new System.Windows.Forms.CheckBox();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.lblPreparedFilesLabel = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tboxError = new System.Windows.Forms.TextBox();
            this.cBoxPreparedFiles = new System.Windows.Forms.ComboBox();
            this.cBoxPage = new System.Windows.Forms.ComboBox();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSelectFolder
            // 
            this.lblSelectFolder.AutoSize = true;
            this.lblSelectFolder.Location = new System.Drawing.Point(12, 9);
            this.lblSelectFolder.Name = "lblSelectFolder";
            this.lblSelectFolder.Size = new System.Drawing.Size(69, 13);
            this.lblSelectFolder.TabIndex = 0;
            this.lblSelectFolder.Text = "Select Folder";
            // 
            // tBoxSelectedFolder
            // 
            this.tBoxSelectedFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxSelectedFolder.Location = new System.Drawing.Point(15, 38);
            this.tBoxSelectedFolder.Name = "tBoxSelectedFolder";
            this.tBoxSelectedFolder.Size = new System.Drawing.Size(353, 26);
            this.tBoxSelectedFolder.TabIndex = 1;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFolder.Location = new System.Drawing.Point(392, 37);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(75, 27);
            this.btnSelectFolder.TabIndex = 2;
            this.btnSelectFolder.Text = "Select";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.SelectFolderOnClick);
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.Location = new System.Drawing.Point(547, 80);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(75, 23);
            this.btnGetFiles.TabIndex = 3;
            this.btnGetFiles.Text = "Get File/s";
            this.btnGetFiles.UseVisualStyleBackColor = true;
            this.btnGetFiles.Click += new System.EventHandler(this.GetFilesForDelete);
            // 
            // cBoxExtensions
            // 
            this.cBoxExtensions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxExtensions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxExtensions.FormattingEnabled = true;
            this.cBoxExtensions.Items.AddRange(new object[] {
            ".jpg",
            ".mkv",
            ".mp3",
            ".mp4",
            ".png",
            ".torrent",
            ".txt"});
            this.cBoxExtensions.Location = new System.Drawing.Point(499, 38);
            this.cBoxExtensions.Name = "cBoxExtensions";
            this.cBoxExtensions.Size = new System.Drawing.Size(123, 28);
            this.cBoxExtensions.Sorted = true;
            this.cBoxExtensions.TabIndex = 4;
            // 
            // lblExtensionLabel
            // 
            this.lblExtensionLabel.AutoSize = true;
            this.lblExtensionLabel.Location = new System.Drawing.Point(509, 9);
            this.lblExtensionLabel.Name = "lblExtensionLabel";
            this.lblExtensionLabel.Size = new System.Drawing.Size(113, 13);
            this.lblExtensionLabel.TabIndex = 5;
            this.lblExtensionLabel.Text = "Select extension of file";
            // 
            // checkBoxRecursiveFolder
            // 
            this.checkBoxRecursiveFolder.AutoSize = true;
            this.checkBoxRecursiveFolder.Location = new System.Drawing.Point(318, 80);
            this.checkBoxRecursiveFolder.Name = "checkBoxRecursiveFolder";
            this.checkBoxRecursiveFolder.Size = new System.Drawing.Size(201, 17);
            this.checkBoxRecursiveFolder.TabIndex = 6;
            this.checkBoxRecursiveFolder.Text = "Delete files in inner folders (recursive)";
            this.checkBoxRecursiveFolder.UseVisualStyleBackColor = true;
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Location = new System.Drawing.Point(547, 146);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(75, 21);
            this.btnRemoveFile.TabIndex = 8;
            this.btnRemoveFile.Text = "Remove File";
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.RemoveFileFromList);
            // 
            // lblPreparedFilesLabel
            // 
            this.lblPreparedFilesLabel.AutoSize = true;
            this.lblPreparedFilesLabel.Location = new System.Drawing.Point(12, 130);
            this.lblPreparedFilesLabel.Name = "lblPreparedFilesLabel";
            this.lblPreparedFilesLabel.Size = new System.Drawing.Size(136, 13);
            this.lblPreparedFilesLabel.TabIndex = 9;
            this.lblPreparedFilesLabel.Text = "These file/s will be deleted.";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(547, 252);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 33);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.DeleteFiles);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(12, 223);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 20);
            this.lblStatus.TabIndex = 11;
            // 
            // tboxError
            // 
            this.tboxError.Location = new System.Drawing.Point(15, 252);
            this.tboxError.Multiline = true;
            this.tboxError.Name = "tboxError";
            this.tboxError.ReadOnly = true;
            this.tboxError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tboxError.Size = new System.Drawing.Size(504, 50);
            this.tboxError.TabIndex = 15;
            // 
            // cBoxPreparedFiles
            // 
            this.cBoxPreparedFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxPreparedFiles.FormattingEnabled = true;
            this.cBoxPreparedFiles.Location = new System.Drawing.Point(15, 146);
            this.cBoxPreparedFiles.MaxDropDownItems = 100;
            this.cBoxPreparedFiles.Name = "cBoxPreparedFiles";
            this.cBoxPreparedFiles.Size = new System.Drawing.Size(504, 21);
            this.cBoxPreparedFiles.TabIndex = 7;
            // 
            // cBoxPage
            // 
            this.cBoxPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxPage.FormattingEnabled = true;
            this.cBoxPage.Location = new System.Drawing.Point(463, 119);
            this.cBoxPage.Name = "cBoxPage";
            this.cBoxPage.Size = new System.Drawing.Size(56, 21);
            this.cBoxPage.TabIndex = 16;
            this.cBoxPage.SelectedIndexChanged += this.OnPageSelect;
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(419, 122);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(38, 13);
            this.lblPage.TabIndex = 17;
            this.lblPage.Text = "Page :";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(547, 119);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.OnClickResetForm);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 305);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.cBoxPage);
            this.Controls.Add(this.tboxError);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblPreparedFilesLabel);
            this.Controls.Add(this.btnRemoveFile);
            this.Controls.Add(this.cBoxPreparedFiles);
            this.Controls.Add(this.checkBoxRecursiveFolder);
            this.Controls.Add(this.lblExtensionLabel);
            this.Controls.Add(this.cBoxExtensions);
            this.Controls.Add(this.btnGetFiles);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.tBoxSelectedFolder);
            this.Controls.Add(this.lblSelectFolder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectFolder;
        private System.Windows.Forms.TextBox tBoxSelectedFolder;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnGetFiles;
        private System.Windows.Forms.ComboBox cBoxExtensions;
        private System.Windows.Forms.Label lblExtensionLabel;
        private System.Windows.Forms.CheckBox checkBoxRecursiveFolder;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.Label lblPreparedFilesLabel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox tboxError;
        private System.Windows.Forms.ComboBox cBoxPreparedFiles;
        private System.Windows.Forms.ComboBox cBoxPage;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnReset;
    }
}

