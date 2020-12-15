namespace DumpImage
{
    using System.Drawing;
    using System.Drawing.Imaging;

    internal static class BitmapExtensions
    {
        public static void SaveAsPng(this Bitmap source, string fileName)
        {
            source.Save($"{fileName}.png", ImageFormat.Png);
        }
    }
}