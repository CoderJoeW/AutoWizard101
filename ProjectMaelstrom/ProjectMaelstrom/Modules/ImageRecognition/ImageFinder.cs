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
        public static Point? FindImageInImage(string targetImagePath)
        {
            using var mainImage = new Image<Bgr, byte>(TakeScreenshot()).Convert<Hsv, byte>();
            using var targetImage = new Image<Bgr, byte>(targetImagePath).Convert<Hsv, byte>();

            var resultWidth = mainImage.Width - targetImage.Width + 1;
            var resultHeight = mainImage.Height - targetImage.Height + 1;

            using var matchResult = new Image<Gray, float>(resultWidth, resultHeight);
            CvInvoke.MatchTemplate(mainImage, targetImage, matchResult, TemplateMatchingType.CcoeffNormed);

            double[] minValues, maxValues;
            Point[] minLocations, maxLocations;
            matchResult.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

            var matchingThreshold = 0.8;
            if (maxValues[0] >= matchingThreshold)
            {
                return maxLocations[0];
            }

            return null;
        }

        public static Point? GetCoordinatesOfImage(string targetImage)
        {
            Point? location = FindImageInImage(targetImage);

            return location;
        }

        public static string TakeScreenshot()
        {
            string imageName = GeneralUtils.Instance.RandomString(20);
            string imageLocation = $"screenshots/{imageName}.png";

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
