using System.Drawing;

namespace TGAConverter.Services.Interfaces
{
    public interface ITgaService
    {
        Bitmap CreateBitmapFromTgaSource(string directoryPath, string filePath);
    }
}