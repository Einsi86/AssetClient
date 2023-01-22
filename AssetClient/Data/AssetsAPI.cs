using AssetClient.Models;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AssetClient.Data
{
    public static class AssetsAPI
    {

        private static readonly HttpClient client = new HttpClient();


        public static List<Asset> GetAllAssets(string Description,string assettype, string user, string status)
        {

            string url = @"http://localhost:" + Settings.port + "/api/GetAsset?description="+Description+"&assettype="+assettype +"&status="+status+"&user=" + user;
                       
            var webRequest = new HttpRequestMessage(HttpMethod.Get, url);

            HttpResponseMessage response ;

            try
            {
                 response = client.Send(webRequest);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                List<Asset> l = new List<Asset>();
                return l; 
            }

            


            if (!response.IsSuccessStatusCode)
            {

            }
            var jsonresponse = response.Content.ReadAsStringAsync();

            List<Asset> Assets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Asset>>(jsonresponse.Result);

            return Assets;
        }

        public static void PutAsset(int AssetId, string Description, string longDescription, int assetTypeId, int statusId, int userId)
        {

            string url = @"http://localhost:" + Settings.port + "/api/PutAsset?id=" + AssetId.ToString();

            var webRequest = new HttpRequestMessage(HttpMethod.Put, url);
            webRequest.Content = JsonContent.Create(new {
                description = Description,
                longDescription = longDescription,
                assetTypeId = assetTypeId,
                statusId = statusId,
                userId = userId
            });

            var response = client.Send(webRequest);
            if (!response.IsSuccessStatusCode)
            {

            }
          

        }


        public static void PostAsset(AssetPost assets)
        {


            string url = @"http://localhost:" + Settings.port + "/api/PostAsset";

            

            var webRequest = new HttpRequestMessage(HttpMethod.Post, url);
            webRequest.Content = JsonContent.Create(assets);

            var response = client.Send(webRequest);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("PostAsset failed!");
            }
            var jsonresponse = response.Content.ReadAsStringAsync();

        }
    }
}
