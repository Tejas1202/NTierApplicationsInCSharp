using Newtonsoft.Json;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JustShowMeMyFriends.WebApiServices
{
    class WebApiUserService : IUserService
    {
        private readonly HttpClient _client;

        public WebApiUserService(HttpClient client)
        {
            _client = client;
        }

        public User GetUserByEmail(string emailAddress)
        {
            string request = String.Format("api/users?email={0}", emailAddress);
            HttpResponseMessage response = _client.GetAsync(request).Result; // blocking call

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                var user = JsonConvert.DeserializeObject<User>(result);

                return user;
            }

            return null;
        }
    }
}
