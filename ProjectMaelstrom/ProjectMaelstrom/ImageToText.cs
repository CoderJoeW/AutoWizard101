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
        private static string endpoint = "https://api.lazarusforms.com/api";

        public static async Task<string> Test(string path)
        {
            try
            {
                var client = new RestClient(endpoint);
                var request = new RestRequest("/forms/generic", Method.Post);
                request.Timeout = -1;
                request.AddHeader("Content-Type", "multipart/form-data");
                request.AddHeader("orgId", Properties.Settings.Default["Lazarus_Organization_Id"].ToString());
                request.AddHeader("authKey", Properties.Settings.Default["Lazarus_Auth_Key"].ToString());
                request.AddFile("file", path);
                RestResponse response = await client.ExecutePostAsync(request);
                
                return response.Content;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
