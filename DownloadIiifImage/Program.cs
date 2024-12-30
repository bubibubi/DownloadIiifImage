using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;

namespace DownloadIiifImage
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();

            var finalImage = new Bitmap(20500, 32000, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(finalImage);

            g.Clear(Color.White);

            for (int x = 0; x < 20575; x += 1500)
            {
                for (int y = 0; y < 31353; y += 1500)
                {
                    string url = $"https://jarvis.edl.beniculturali.it/images/iiif/db/c1e43580-f3c5-420a-bc5a-799ca9364d9e/{x},{y},1500,1500/max/0/default.jpg";
                    string name = $"C:\\TEMP\\{x}-{y}.jpg";
                    client.DownloadFile(url, name);


                    Bitmap image = new Bitmap(name);
                    g.DrawImage(image, new Rectangle(x, y, 1500, 1500));
                }
            }

            g.Dispose();

            finalImage.Save("C:\\TEMP\\Complete.jpg", ImageFormat.Jpeg);

        }

    }
}
