namespace DeleteFiles.Repo
{
    using System.Collections.Generic;
    using System.Linq;
    using DeleteFiles.Interfaces;

    internal class DeleterRepo : IDeleterRepo
    {
        private IList<string> foundFiles;

        public DeleterRepo()
        {
            this.foundFiles = new List<string>();
        }

        public void Add(string file)
        {
            this.foundFiles.Add(file);
        }

        public void AddAll(IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                this.Add(file);
            }
        }

        public bool Remove(string file)
        {
            if (!this.foundFiles.Any() || !this.foundFiles.Contains(file))
            {
                return false;
            }

            this.foundFiles.Remove(file);

            return true;
        }

        public string[] ShowFilesPerPage(int page, int resultsPerPage)
        {
            var tempCollection = new HashSet<string>();

            int startIndex = (page - 1) * resultsPerPage;
            int endIndex = (page * resultsPerPage) < this.foundFiles.Count
                ? (page * resultsPerPage)
                : this.foundFiles.Count;

            for (int i = startIndex; i < endIndex; i++)
            {
                tempCollection.Add(this.foundFiles[i]);
            }

            return tempCollection.ToArray();
        }

        public int GetPages(int resultsPerPage)
        {
            var numOfPages = this.foundFiles.Count / resultsPerPage;

            if (numOfPages * resultsPerPage < this.foundFiles.Count)
            {
                numOfPages++;
            }

            return numOfPages;
        }

        public IEnumerable<string> GetAllFiles()
        {
            return this.foundFiles;
        }

        public bool Clear()
        {
            this.foundFiles.Clear();

            if (this.foundFiles.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
