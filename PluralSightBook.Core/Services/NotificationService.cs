using PluralSightBook.Core.Interfaces;
using System;

namespace PluralSightBook.Core.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IQueryUsersByEmail _queryUserByEmail;
        private readonly ISendEmail _emailSender;

        public NotificationService(IQueryUsersByEmail queryUserByEmail, ISendEmail emailSender)
        {
            _queryUserByEmail = queryUserByEmail;
            _emailSender = emailSender;
        }

        public void SendNotification(string currentUserEmail, string currentUserName, string friendEmail)
        {
            string emailBody = "";

            bool isFriendMember = _queryUserByEmail.UserWithEmailExists(friendEmail);

            if (isFriendMember)
            {
                // do they already list current user as one of their friends?
                var friendUserId = _queryUserByEmail.GetUserByEmail(friendEmail).UserId;
                bool currentUserAlreadyFriend = _queryUserByEmail.IsUserWithEmailFriendOfUser(friendUserId, currentUserEmail);
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

            _emailSender.SendEmail(emailBody);
            
        }
    }
}