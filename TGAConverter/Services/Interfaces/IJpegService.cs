using System.Drawing;

namespace TGAConverter.Services.Interfaces
{
    public interface IJpegService
    {
        void SaveBitmapToJpeg(Bitmap bitmap, string outputDirectoryPath, string fileName);
    }
}