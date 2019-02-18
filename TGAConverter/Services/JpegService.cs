using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using TGAConverter.Services.Interfaces;

namespace TGAConverter.Services
{
    public class JpegService : IJpegService
    {
        public void SaveBitmapToJpeg(Bitmap bitmap, string outputDirectoryPath, string fileName)
        {
            bitmap.Save($@"{outputDirectoryPath}\{TrimTgaExtensionFromFilename(fileName)}.jpg", ImageFormat.Jpeg);
        }

        private static string TrimTgaExtensionFromFilename(string fileName)
        {
            return fileName.Split('.').First();
        }
    }
}