namespace DumpImage
{
    using System.Drawing;
    using System.IO;
    using System.Windows.Media.Imaging;

    internal static class BitmapSourceExtensions
    {
        public static Bitmap ToBitmap(this BitmapSource source)
        {
            Bitmap bitmap;

            using (var stream = new MemoryStream())
            {
                var encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(source));
                encoder.Save(stream);
                bitmap = new Bitmap(stream);
            }

            return bitmap;
        }
    }
}
