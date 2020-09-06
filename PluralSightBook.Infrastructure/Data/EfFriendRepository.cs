using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluralSightBook.Infrastructure.Data
{
    public class EfFriendRepository : IFriendRepository
    {
        public void Create(Guid userId, string emailAddress)
        {
            var context = new aspnetdbEntities();
            var newFriend = context.Friends.Create();
            newFriend.UserId = userId;
            newFriend.EmailAddress = emailAddress;
            context.Friends.Add(newFriend);
            context.SaveChanges();
        }

        public void Delete(int friendId)
        {
            var context = new aspnetdbEntities();
            var friendToDelete = context.Friends.FirstOrDefault(f => f.Id == friendId);
            context.Friends.Remove(friendToDelete);
            context.SaveChanges();
        }

        public IEnumerable<Core.Models.Friend> ListFriendsOfUser(Guid userId)
        {
            var context = new aspnetdbEntities();

            return context.Friends
                .Where(f => f.UserId == userId)
                .Select(f => new Core.Models.Friend()
                {
                    Id = f.Id,
                    EmailAddress = f.EmailAddress
                });
        }

    }
}
