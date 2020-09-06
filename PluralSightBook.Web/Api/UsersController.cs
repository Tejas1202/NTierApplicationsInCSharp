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
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users?emailAddress=sunny@gmail.com
        public User GetUsersByEmail(string email)
        {
            return _userService.GetUserByEmail(email);
        }
    }
}
