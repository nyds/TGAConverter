using System.Drawing;
using System.IO;
using DmitryBrant.ImageFormats;
using TGAConverter.Services.Interfaces;

namespace TGAConverter.Services
{
    public class TgaService: ITgaService
    {
        public Bitmap CreateBitmapFromTgaSource(string directoryPath, string fileName)
        {
            using (var fs = new FileStream($@"{directoryPath}\{fileName}", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return TgaReader.Load(fs);
            }
        }
    }
}