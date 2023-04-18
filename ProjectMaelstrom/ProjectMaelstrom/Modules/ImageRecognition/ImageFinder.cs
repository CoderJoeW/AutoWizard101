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
        public static Point? SearchForTargetImageWithinScreenshot(string targetImagePath)
        {
            using var capturedScreenshot = new Image<Bgr, byte>(CaptureScreen()).Convert<Hsv, byte>();
            using var targetImage = new Image<Bgr, byte>(targetImagePath).Convert<Hsv, byte>();

            var comparisonWidth = capturedScreenshot.Width - targetImage.Width + 1;
            var comparisonHeight = capturedScreenshot.Height - targetImage.Height + 1;

            using var matchingResult = new Image<Gray, float>(comparisonWidth, comparisonHeight);
            CvInvoke.MatchTemplate(capturedScreenshot, targetImage, matchingResult, TemplateMatchingType.CcoeffNormed);

            double[] minValues, maxValues;
            Point[] minLocations, maxLocations;
            matchingResult.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

            var matchingThreshold = 0.8;
            if (maxValues[0] >= matchingThreshold)
            {
                return maxLocations[0];
            }

            return null;
        }

        public static Point? RetrieveTargetImagePositionInScreenshot(string targetImagePath)
        {
            Point? position = SearchForTargetImageWithinScreenshot(targetImagePath);

            return position;
        }

        public static string CaptureScreen()
        {
            string randomScreenshotName = GeneralUtils.Instance.RandomString(20);
            string screenshotFilePath = $"screenshots/{randomScreenshotName}.png";

            using (var bitmapScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format24bppRgb))
            {
                using (var graphicsScreenshot = Graphics.FromImage(bitmapScreenshot))
                {
                    graphicsScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.Location, Point.Empty, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                    bitmapScreenshot.Save(screenshotFilePath, ImageFormat.Png);
                }
            }

            return screenshotFilePath;
        }
    }
}