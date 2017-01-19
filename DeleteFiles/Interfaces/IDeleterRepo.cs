namespace DeleteFiles.Interfaces
{
    using System.Collections.Generic;

    internal interface IDeleterRepo
    {
        void Add(string file);

        void AddAll(IEnumerable<string> files);

        bool Remove(string file);

        bool Clear();

        string[] ShowFilesPerPage(int page, int resultsPerPage);

        int GetPages(int resultsPerPage);

        IEnumerable<string> GetAllFiles();
    }
}
