using System.Collections.Generic;
using System.IO;
using System.Linq;
using TGAConverter.Services.Interfaces;

namespace TGAConverter.Services
{
    public class FileService: IFileService
    {
        private const string OutputDirectoryName = "JPG";

        public string WorkingDirectory { get; private set; }
        public string OutputDirectory { get; private set; }

        public IEnumerable<string> GetTgaFilesFromWorkingDirectory()
        {
            WorkingDirectory = Directory.GetCurrentDirectory();
            return Directory.GetFiles(WorkingDirectory, "*.tga").Select(Path.GetFileName);
        }

        public string GetWorkingDirectoryPath()
        {
            return WorkingDirectory;
        }

        public string GetOutputDirectoryPath()
        {
            return !string.IsNullOrEmpty(OutputDirectory) ? OutputDirectory : SetupOutputDirectory();
        }

        private string SetupOutputDirectory()
        {
            var outputDirectory = $@"{WorkingDirectory}\{OutputDirectoryName}";

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            OutputDirectory = outputDirectory;
            return OutputDirectory;
        }
    }
}