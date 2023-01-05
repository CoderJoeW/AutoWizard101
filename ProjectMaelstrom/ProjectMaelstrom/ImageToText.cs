using Newtonsoft.Json;
using ProjectMaelstrom.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaelstrom
{
    internal class ImageToText
    {
        private static string endpoint = "https://api.ocr.space/Parse/Image";

        public static async Task<OcrResultModel> GetStringsFromImage(string path)
        {
            try
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                form.Add(new StringContent(Properties.Settings.Default["OCR_SPACE_APIKEY"].ToString()), "apikey");
                form.Add(new StringContent("eng"), "language");
                form.Add(new StringContent("2"), "ocrengine");

                byte[] imageData = File.ReadAllBytes(path);
                form.Add(new ByteArrayContent(imageData, 0, imageData.Length), "image", "image.png");


                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(1, 1, 1);

                HttpResponseMessage response = await httpClient.PostAsync(endpoint, form);

                string strContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<OcrResultModel>(strContent);
            }
            catch (Exception ex)
            {
                return new OcrResultModel();
            }
        }
    }
}
