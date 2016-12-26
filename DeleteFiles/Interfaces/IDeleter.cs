namespace DeleteFiles.Interfaces
{
    using System.Collections.Generic;

    internal interface IDeleter
    {
        string[] GetFilesForDelete(string directoryPath, bool recursive, string extension);

        int DeleteFiles(IEnumerable<string> filess);

        string[] GetLogs { get; }
    }
}
