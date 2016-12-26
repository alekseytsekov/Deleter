
namespace DeleteFiles.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using DeleteFiles.Interfaces;

    internal class Deleter : IDeleter
    {
        private ICollection<string> logs;

        public Deleter()
        {
            this.logs = new HashSet<string>();
        }

        public string[] GetFilesForDelete(string directoryPath, bool recursive, string extension)
        {
            ICollection<string> container = new List<string>();
            
            this.GetFiles(directoryPath, recursive, container, extension);

            return container.ToArray();
        }
        
        public int DeleteFiles(IEnumerable<string> filess)
        {
            int deletedFilesCount = 0;
            
            foreach (var file in filess)
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

            return deletedFilesCount;
        }

        public string[] GetLogs
        {
            get { return this.logs.ToArray(); }
        }

        private void GetFiles(string directoryPath, bool recursive, ICollection<string> container, string extension)
        {
            var filesInDirectory = Directory.GetFiles(directoryPath).Where(file => file.EndsWith(extension));

            foreach (var file in filesInDirectory)
            {
                container.Add(file);
            }

            if (recursive)
            {
                var directories = Directory.GetDirectories(directoryPath);

                foreach (var directory in directories)
                {
                    try
                    {
                        var dir = new DirectoryInfo(directory).Attributes;

                        if ((dir & FileAttributes.System) != 0)
                        {
                            continue;
                        }
                        this.GetFiles(directory, recursive, container, extension);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue;
                    }
                }
            }
        }
    }
}
