using PluralSight.DAL;
using System;
using System.Diagnostics;
using System.Linq;

namespace Pluralsight.BLL
{
    public class NotificationService
    {
        public void SendNotification(string currentUserEmail, string currentUserName, string friendEmail)
        {
            string emailBody = "";
            var context = new aspnetdbEntities();

            var userService = new UserService();
            bool isFriendMember = userService.IsEmailRegistered(friendEmail);

            if (isFriendMember)
            {
                // do they already list current user as one of their friends?
                var friendUserId = userService.GetUserByEmail(friendEmail).UserId;
                bool currentUserAlreadyFriend = context.Friends.Any(f => f.UserId == friendUserId && f.EmailAddress == currentUserEmail);
                if (currentUserAlreadyFriend)
                {
                    emailBody = String.Format(@"Good News! friend {0} just added you as a friend!", currentUserEmail);
                }
                else
                {
                    emailBody = String.Format(@"{0} added you as a friend on PluralsightBook!  Click here to add them as your friend:
 http://localhost:4927/QuickAddFriend.aspx?email={1}",
                                                   currentUserName,
                                                   currentUserEmail);
                }
            }
            else
            {
                emailBody = String.Format(@"{0} added you as a friend on PluralsightBook!  Click here to register your own account and then add them as your friend: http://localhost:4927/QuickAddFriend.aspx?email={1}",
                               currentUserName,
                               currentUserEmail);

            }
            // send email
            Debug.Print("Sending Email: " + emailBody);
        }
    }
}
