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
        public static Point? FindTargetImageInMainImage(string targetImagePath)
        {
            using var mainImage = new Image<Bgr, byte>(CaptureScreenshot()).Convert<Hsv, byte>();
            using var targetImage = new Image<Bgr, byte>(targetImagePath).Convert<Hsv, byte>();

            var resultWidth = mainImage.Width - targetImage.Width + 1;
            var resultHeight = mainImage.Height - targetImage.Height + 1;

            using var matchResultImage = new Image<Gray, float>(resultWidth, resultHeight);
            CvInvoke.MatchTemplate(mainImage, targetImage, matchResultImage, TemplateMatchingType.CcoeffNormed);

            double[] minValues, maxValues;
            Point[] minLocations, maxLocations;
            matchResultImage.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

            var matchingThreshold = 0.8;
            if (maxValues[0] >= matchingThreshold)
            {
                return maxLocations[0];
            }

            return null;
        }

        public static Point? GetTargetImageCoordinates(string targetImagePath)
        {
            Point? location = FindTargetImageInMainImage(targetImagePath);

            return location;
        }

        public static string CaptureScreenshot()
        {
            string randomImageName = GeneralUtils.Instance.RandomString(20);
            string screenshotLocation = $"screenshots/{randomImageName}.png";

            using (var bitmapScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format24bppRgb))
            {
                using (var graphicsScreenshot = Graphics.FromImage(bitmapScreenshot))
                {
                    graphicsScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.Location, Point.Empty, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                    bitmapScreenshot.Save(screenshotLocation, ImageFormat.Png);
                }
            }

            return screenshotLocation;
        }
    }
}
