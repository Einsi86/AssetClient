using AssetClient.Models;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetClient.Data
{
    public static class Types
    {
        private static readonly HttpClient client = new HttpClient();


        public static List<User> GetUsers()
        {

            string url = @"http://localhost:" + Settings.port + "/GetUser";

            var webRequest = new HttpRequestMessage(HttpMethod.Get, url);

            var response = client.Send(webRequest);
            if (!response.IsSuccessStatusCode)
            {

            }
            var jsonresponse = response.Content.ReadAsStringAsync();

            List<User> Users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(jsonresponse.Result);

            return Users;
        }

        public static List<Status> GetStatuses()
        {

            string url = @"http://localhost:" + Settings.port + "/GetStatus";

            var webRequest = new HttpRequestMessage(HttpMethod.Get, url);

            var response = client.Send(webRequest);
            if (!response.IsSuccessStatusCode)
            {

            }
            var jsonresponse = response.Content.ReadAsStringAsync();

            List<Status> Statuses = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Status>>(jsonresponse.Result);

            return Statuses;
        }

        public static List<AssetType> GetAssetTypes()
        {

            string url = @"http://localhost:" + Settings.port + "/GetType";

            var webRequest = new HttpRequestMessage(HttpMethod.Get, url);

            var response = client.Send(webRequest);
            if (!response.IsSuccessStatusCode)
            {

            }
            var jsonresponse = response.Content.ReadAsStringAsync();

            List<AssetType> AssetTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AssetType>>(jsonresponse.Result);

            return AssetTypes;
        }

        public static void PostAssetType(string description)
        {


            string url = @"http://localhost:" + Settings.port + "/PostType?description=" + description;



            var webRequest = new HttpRequestMessage(HttpMethod.Post, url);

            var response = client.Send(webRequest);
            if (!response.IsSuccessStatusCode)
            {

            }
            var jsonresponse = response.Content.ReadAsStringAsync();

        }


        public static void PostStatus(string description)
        {


            string url = @"http://localhost:" + Settings.port + "/PostStatus?description=" + description;



            var webRequest = new HttpRequestMessage(HttpMethod.Post, url);

            var response = client.Send(webRequest);
            if (!response.IsSuccessStatusCode)
            {

            }
            var jsonresponse = response.Content.ReadAsStringAsync();

        }

        public static void PostUser(UserPost u)
        {


            string url = @"http://localhost:" + Settings.port + "/PostUser?name=" + u.Name +"&email="+u.Email+"&phone="+u.Phone+"&location=" + u.Location;



            var webRequest = new HttpRequestMessage(HttpMethod.Post, url);

            var response = client.Send(webRequest);
            if (!response.IsSuccessStatusCode)
            {

            }
            var jsonresponse = response.Content.ReadAsStringAsync();

        }
    }
}
