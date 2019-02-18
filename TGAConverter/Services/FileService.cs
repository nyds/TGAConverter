using System.Collections.Generic;
using System.IO;
using System.Linq;
using TGAConverter.Services.Interfaces;

namespace TGAConverter.Services
{
    public class FileService: IFileService
    {
        private const string OutputDirectoryName = "JPG";

        private readonly string _workingDirectory;
        private readonly string _outputDirectory;

        public FileService()
        {
            _workingDirectory = Directory.GetCurrentDirectory();
            _outputDirectory = SetupOutputDirectory();
        }

        public IEnumerable<string> GetTgaFilesFromWorkingDirectory()
        {
            return Directory.GetFiles(_workingDirectory, "*.tga").Select(Path.GetFileName);
        }

        public string GetWorkingDirectoryPath()
        {
            return _workingDirectory;
        }

        public string GetOutputDirectoryPath()
        {
            return _outputDirectory;
        }

        private string SetupOutputDirectory()
        {
            var outputDirectory = $@"{_workingDirectory}\{OutputDirectoryName}";

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            return _outputDirectory;
        }
    }
}