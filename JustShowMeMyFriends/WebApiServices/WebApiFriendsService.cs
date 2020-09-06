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
    class WebApiFriendsService : IFriendsService
    {
        private readonly HttpClient _client;

        public WebApiFriendsService(HttpClient client)
        {
            _client = client;
        }

        public void AddFriend(Guid currentUserId, string currentUserEmail, string currentUserName, string friendEmail)
        {
            throw new NotImplementedException();
        }

        public void DeleteFriend(int friendId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Friend> ListFriendsOf(Guid userId)
        {
            string request = String.Format("api/friends?userId={0}", userId);
            HttpResponseMessage response = _client.GetAsync(request).Result; // blocking call

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                var friends = JsonConvert.DeserializeObject<IEnumerable<Friend>>(result);

                return friends;
            }

            return null;
        }
    }
}
