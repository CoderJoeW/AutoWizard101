using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ProjectMaelstrom.Utilities;

namespace ProjectMaelstrom.Modules.ImageRecognition
{
    internal class ImageFinder
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static Point? SearchForTargetImageWithinScreenshot(string targetImagePath)
        {
            IntPtr windowHandle = GetWindowHandle();
            if (windowHandle == IntPtr.Zero)
            {
                throw new Exception("Window not found.");
            }

            RECT rect = GetWindowRect(windowHandle);

            int windowLeft = rect.Left;
            int windowTop = rect.Top;

            string screenshotPath = CaptureScreen(rect);

            using var capturedScreenshot = new Image<Bgr, byte>(screenshotPath).Convert<Hsv, byte>();
            using var targetImage = new Image<Bgr, byte>(targetImagePath).Convert<Hsv, byte>();

            var comparisonWidth = capturedScreenshot.Width - targetImage.Width + 1;
            var comparisonHeight = capturedScreenshot.Height - targetImage.Height + 1;

            using var matchingResult = new Image<Gray, float>(comparisonWidth, comparisonHeight);
            CvInvoke.MatchTemplate(capturedScreenshot, targetImage, matchingResult, TemplateMatchingType.CcoeffNormed);

            double[] minValues, maxValues;
            Point[] minLocations, maxLocations;
            matchingResult.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

            double matchingThreshold = 0.75;
            if (maxValues[0] >= matchingThreshold)
            {
                Point matchingPoint = maxLocations[0];

                matchingPoint.X += windowLeft;
                matchingPoint.Y += windowTop;

                return matchingPoint;
            }

            return null;
        }


        public static Point? RetrieveTargetImagePositionInScreenshot(string targetImagePath)
        {
            Point? position = SearchForTargetImageWithinScreenshot(targetImagePath);

            return position;
        }

        public static string CaptureScreen(RECT rect)
        {
            string randomScreenshotName = GeneralUtils.Instance.RandomString(20);
            string screenshotFilePath = $"screenshots/{randomScreenshotName}.png";

            int width = rect.Right - rect.Left;
            int height = rect.Bottom - rect.Top;

            using (var bitmapScreenshot = new Bitmap(width, height, PixelFormat.Format24bppRgb))
            {
                using (var graphicsScreenshot = Graphics.FromImage(bitmapScreenshot))
                {
                    graphicsScreenshot.CopyFromScreen(new Point(rect.Left, rect.Top), Point.Empty, new Size(width, height), CopyPixelOperation.SourceCopy);
                    bitmapScreenshot.Save(screenshotFilePath, ImageFormat.Png);
                }
            }

            return screenshotFilePath;
        }

        public static IntPtr GetWindowHandle()
        {
            return FindWindow(null, "Wizard101");
        }

        public static RECT GetWindowRect(IntPtr windowHandle)
        {
            if (GetWindowRect(windowHandle, out RECT rect))
            {
                return rect;
            } else
            {
                throw new Exception("Failed to retrieve window position.");
            }
        }
    }
}