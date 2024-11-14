using Emgu.CV;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaelstrom.Modules.ImageRecognition
{
    internal static class ImageHelpers
    {
        public static async Task<string> ExtractTextFromImage(string imagePath)
        {
            ImageHelpers.ConvertImageToGrayscale(imagePath);
            string apiKey = Properties.Settings.Default["OCR_SPACE_APIKEY"].ToString();
            string apiUrl = "https://api.ocr.space/parse/image";

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("apikey", apiKey);

            using var formData = new MultipartFormDataContent();

            using FileStream fileStream = File.OpenRead(imagePath);
            using var streamContent = new StreamContent(fileStream);
            using var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync());

            string fileExtension = Path.GetExtension(imagePath).ToLower();
            string contentType = fileExtension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                ".tiff" or ".tif" => "image/tiff",
                _ => throw new NotSupportedException($"File extension {fileExtension} is not supported")
            };

            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
            formData.Add(fileContent, "file", Path.GetFileName(imagePath));

            var response = await httpClient.PostAsync(apiUrl, formData);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            JObject parsedResponse = JObject.Parse(jsonResponse);
            string text = parsedResponse["ParsedResults"][0]["ParsedText"].ToString();

            return text;
        }

        public static void ConvertImageToGrayscale(string imagePath)
        {
            using var img = new Mat(imagePath);
            using var grayImg = new Mat();
            CvInvoke.CvtColor(img, grayImg, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            grayImg.Clone().Save(imagePath);
        }
    }
}
