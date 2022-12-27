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
        private static string orgId = "xxxx";
        private static string authKey = "xxxx";

        public static async Task<string> Test(string path)
        {
            try
            {
                var client = new RestClient(endpoint);
                var request = new RestRequest("/forms/generic", Method.Post);
                request.Timeout = -1;
                request.AddHeader("Content-Type", "multipart/form-data");
                request.AddHeader("orgId", orgId);
                request.AddHeader("authKey", authKey);
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
