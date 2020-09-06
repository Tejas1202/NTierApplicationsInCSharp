using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluralSightBook.Infrastructure.Data
{
    public class EfQueryUserByEmail : IQueryUsersByEmail
    {
        public bool UserWithEmailExists(string email)
        {
            var context = new aspnetdbEntities();

            return context.aspnet_Membership.Any(m => m.Email == email);
        }

        public User GetUserByEmail(string email)
        {
            var context = new aspnetdbEntities();

            return context.aspnet_Membership.
                Where(m => m.Email == email).
                Select(m => new User()
                {
                    UserId = m.UserId,
                    EmailAddress = m.Email
                }).
                FirstOrDefault();
        }

        public bool IsUserWithEmailFriendOfUser(Guid userId, string emailAddressOfPotentialFriend)
        {
            var context = new aspnetdbEntities();

            return context.Friends.Any(f => f.UserId == userId && f.EmailAddress == emailAddressOfPotentialFriend);
        }
    }
}
