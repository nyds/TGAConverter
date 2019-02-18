using System;
using TGAConverter.Services.Interfaces;

namespace TGAConverter.Application
{
    public class Application
    {
        private readonly IFileService _fileService;
        private readonly ITgaService _tgaService;
        private readonly IJpegService _jpegService;

        public Application(IFileService fileService, ITgaService tgaService, IJpegService jpegService)
        {
            _fileService = fileService;
            _tgaService = tgaService;
            _jpegService = jpegService;
        }

        public void Run()
        {
            Console.WriteLine("Converting your TGA images to JPEG!");

            ConvertTgaFiles();
        }

        private void ConvertTgaFiles()
        {
            var files = _fileService.GetTgaFilesFromWorkingDirectory();

            var workingDirectory = _fileService.GetWorkingDirectoryPath();
            var outputDirectory = _fileService.GetOutputDirectoryPath();

            foreach (var fileName in files)
            {
                try
                {
                    ConvertTgaFile(fileName, workingDirectory, outputDirectory);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Unable to write to directory {outputDirectory}, run converter as administrator.");
                    break;
                }
            }
        }

        private void ConvertTgaFile(string fileName, string workingDirectory, string outputDirectory)
        {
            var image = _tgaService.CreateBitmapFromTgaSource(workingDirectory, fileName);
            _jpegService.SaveBitmapToJpeg(image, outputDirectory, fileName);
        }
    }
}