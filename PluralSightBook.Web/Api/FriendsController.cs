using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PluralSightBook.Web.Api
{
    public class FriendsController : ApiController
    {
        private readonly IFriendsService _friendsService;

        public FriendsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        // GET api/friends?userId=11531f6b-37ec-479a-9413-2af9ea76c56f
        public IEnumerable<Friend> GetFriendsOfUser(Guid userId)
        {
            return _friendsService.ListFriendsOf(userId);
        }
    }
}
