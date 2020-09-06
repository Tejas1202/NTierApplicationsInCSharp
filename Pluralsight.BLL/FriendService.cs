using PluralSight.DAL;
using System;

namespace Pluralsight.BLL
{
    public class FriendsService
    { 
        public void AddFriend(Guid currentUserId, string currentUserEmail, string currentUserName, string friendEmail)
        {
            var context = new aspnetdbEntities();
            var newFriend = context.Friends.Create();
            newFriend.UserId = currentUserId;
            newFriend.EmailAddress = friendEmail;
            context.Friends.Add(newFriend);
            context.SaveChanges();
            var notificationService = new NotificationService();
            notificationService.SendNotification(currentUserEmail, currentUserName, friendEmail);
        }
    }
}
