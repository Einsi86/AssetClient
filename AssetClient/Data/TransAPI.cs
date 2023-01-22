using AssetClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetClient.Data
{
    public static class TransAPI
    {
        private static readonly HttpClient client = new HttpClient();


        public static List<Trans> GetTransByAssetID(int id)
        {


            string url = @"http://localhost:" + Settings.port + "/GetTransaction?Id=" + id.ToString(); ;



            var webRequest = new HttpRequestMessage(HttpMethod.Get, url);

            var response = client.Send(webRequest);
            if (!response.IsSuccessStatusCode)
            {

            }
            var jsonresponse = response.Content.ReadAsStringAsync();

            List<Trans> Transactions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Trans>>(jsonresponse.Result);


            //List<Asset> Assets = new List<Asset>();
            return Transactions;
        }



        public static void PostTrans(int id, string comment)
        {


            string url = @"http://localhost:" + Settings.port + "/PostTransaction?AssetId=" + id + "&Comment=" + comment; ;



            var webRequest = new HttpRequestMessage(HttpMethod.Post, url);

            var response = client.Send(webRequest);
            if (!response.IsSuccessStatusCode)
            {

            }
            var jsonresponse = response.Content.ReadAsStringAsync();

        }
    }
}
