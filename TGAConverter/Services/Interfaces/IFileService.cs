using System.Collections.Generic;

namespace TGAConverter.Services.Interfaces
{
    public interface IFileService
    {
        IEnumerable<string> GetTgaFilesFromWorkingDirectory();
        string GetWorkingDirectoryPath();
        string GetOutputDirectoryPath();
    }
}