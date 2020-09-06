using PluralSightBook.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSightBook.IntegrationTests.Spikes.ActiveRecord
{
    // Active record pattern (for designing our persistence strategy/API)
    // Friend domain class automatically persisting itself (whereas we had only properties in our Friend class in DDD)
    // Hence here the persistence logic as well as business logic is coupled to the domain model itself
    public class ActiveRecordFriend
    {
        private Friend friendEntity;

        public ActiveRecordFriend(int id)
        {
            using (var context = new aspnetdbEntities())
            {
                friendEntity = context.Friends.FirstOrDefault(f => f.Id == id);
            }
            if (friendEntity == null)
                throw new ApplicationException("Specified friend does not exist " + id);
        }

        public int Id
        {
            get { return friendEntity.Id;  }
            set { friendEntity.Id = value; }
        }

        public string EmailAddress
        {
            get { return friendEntity.EmailAddress; }
            set { friendEntity.EmailAddress = value; }
        }

        public void Save()
        {
            using (var context = new aspnetdbEntities())
            {
                context.Friends.Attach(friendEntity);
                context.SaveChanges();
            }
        }

        public static ActiveRecordFriend CreateNew(string emailAddress, Guid userId)
        {
            using (var context = new aspnetdbEntities())
            {
                var friend = context.Friends.Create();
                friend.EmailAddress = emailAddress;
                friend.UserId = userId;
                context.Friends.Add(friend);
                context.SaveChanges();
                return new ActiveRecordFriend(friend.Id);
            }
        }

        // Business logic
        public string EmailDomain
        {
            get
            {
                return EmailAddress.Substring(EmailAddress.LastIndexOf('@') + 1);
            }
        }
    }
}
