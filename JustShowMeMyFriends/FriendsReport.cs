using PluralSightBook.Core.Interfaces;
using System;
using System.Text;

namespace JustShowMeMyFriends
{
    public class FriendsReport
    {
        private readonly IUserService _userService;
        private readonly IFriendsService _friendsService;

        public FriendsReport(IUserService userService, IFriendsService friendsService)
        {
            _userService = userService;
            _friendsService = friendsService;
        }

        public string ShowFriendsReport(string userEmail)
        {
            var user = _userService.GetUserByEmail(userEmail);

            var friends = _friendsService.ListFriendsOf(user.UserId);

            var stringBuilder = new StringBuilder();
            foreach(var friend in friends)
            {
                stringBuilder.Append(friend.EmailAddress);
                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}