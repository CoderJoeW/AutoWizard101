using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ProjectMaelstrom.Utilities;

namespace ProjectMaelstrom.Modules.ImageRecognition
{
    internal class ImageFinder
    {
        public static Point? FindImageInImage(string imagePath2)
        {
            using var image1 = new Image<Bgr, byte>(TakeScreenshot()).Convert<Hsv, byte>();
            using var image2 = new Image<Bgr, byte>(imagePath2).Convert<Hsv, byte>();

            var resultWidth = image1.Width - image2.Width + 1;
            var resultHeight = image1.Height - image2.Height + 1;

            using var result = new Image<Gray, float>(resultWidth, resultHeight);
            CvInvoke.MatchTemplate(image1, image2, result, TemplateMatchingType.CcoeffNormed);

            double[] minValues, maxValues;
            Point[] minLocations, maxLocations;
            result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

            var threshold = 0.8;
            if (maxValues[0] >= threshold)
            {
                return maxLocations[0];
            }

            return null;
        }

        public static Point? GetCoordsOfImage(string image2)
        {
            Point? location = FindImageInImage(image2);

            return location;
        }

        public static string TakeScreenshot()
        {
            string imgKey = GeneralUtils.Instance.RandomString(20);
            string imageLocation = $"screenshots/{imgKey}.png";

            using (var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format24bppRgb))
            {
                using (var gfxScreenshot = Graphics.FromImage(bmpScreenshot))
                {
                    gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.Location, Point.Empty, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                    bmpScreenshot.Save(imageLocation, ImageFormat.Png);
                }
            }

            return imageLocation;
        }
    }
}
