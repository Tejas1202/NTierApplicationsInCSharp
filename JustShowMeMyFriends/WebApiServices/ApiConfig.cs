using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace JustShowMeMyFriends.WebApiServices
{
    public class ApiConfig
    {
        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            string baseApiAddress = ConfigurationManager.AppSettings["baseApiAddress"];
            client.BaseAddress = new Uri(baseApiAddress);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
