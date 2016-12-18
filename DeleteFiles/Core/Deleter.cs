using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DeleteFiles.Core
{
    internal class Deleter
    {
        private string extension;
        private ICollection<string> files;
        private ICollection<string> logs;

        internal Deleter(string extension)
        {
            this.extension = extension;
            this.files = new HashSet<string>();
            this.logs = new HashSet<string>();
        }

        internal IEnumerable<string> GetFilesForDelete(string directoryPath, bool recursive)
        {
            this.GetFiles(directoryPath, recursive);

            return this.files;
        }

        internal bool DeleteFileFromList(string filePath)
        {
            if (!this.files.Contains(filePath))
            {
                return false;
            }
            var isDeleted = this.files.Remove(filePath);

            return isDeleted;
        }

        private void GetFiles(string directoryPath, bool recursive)
        {
            var filesInDirectory = Directory.GetFiles(directoryPath).Where(file => file.EndsWith(this.extension));

            foreach (var file in filesInDirectory)
            {
                this.files.Add(file);
            }

            if (recursive)
            {
                var directories = Directory.GetDirectories(directoryPath);

                foreach (var directory in directories)
                {
                    this.GetFiles(directory, recursive);
                }
            }
        }

        internal int DeleteFiles()
        {
            int deletedFilesCount = 0;
            
            foreach (var file in this.files)
            {
                try
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                        deletedFilesCount++;
                    }
                }
                catch (Exception ex)
                {
                    this.logs.Add(ex.Message);
                }
            }

            if (this.logs.Count == 0)
            {
                this.files.Clear();
                this.logs.Clear();
            }
            else
            {
                this.files.Clear();
            }

            return deletedFilesCount;
        }

        internal string[] GetLogs
        {
            get { return this.logs.ToArray(); }
        }

    }
}
