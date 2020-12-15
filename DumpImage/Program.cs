namespace DumpImage
{
    using System;
    using System.Drawing;
    using System.Windows;

    using Point = System.Drawing.Point;
    using Size = System.Drawing.Size;

    internal static class Program
    {
        [STAThread]
        internal static void Main(string[] args)
        {
            try
            {
                if (Clipboard.ContainsImage())
                {
                    var bitmap = Clipboard.GetImage().ToBitmap();

                    var leftTop = new Point(575, 29);
                    var size = new Size(1913 - 575, 2307 - 29);

                    var rectangle = new Rectangle(leftTop, size);

                    bitmap = CropImage(bitmap, rectangle);

                    bitmap.SaveAsPng($"{DateTime.UtcNow.Ticks}");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        internal static Bitmap CropImage(Bitmap source, Rectangle section)
        {
            var bitmap = new Bitmap(section.Width, section.Height);

            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
                return bitmap;
            }
        }
    }
}
