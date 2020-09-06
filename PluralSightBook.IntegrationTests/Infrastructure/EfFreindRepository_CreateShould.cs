using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSightBook.Infrastructure.Data;
using System;
using System.Linq;

namespace PluralSightBook.IntegrationTests.Infrastructure
{
    [TestClass]
    class EfFreindRepository_CreateShould
    {
        [TestMethod]
        public void AddRecord()
        {
            var context = new aspnetdbEntities();
            var testUser = context.aspnet_Membership.First();
            var friendRepository = new EfFriendRepository();
            var testFreindEmail = Guid.NewGuid().ToString();

            friendRepository.Create(testUser.UserId, testFreindEmail);

            bool friendExists = context.Friends.Any(f => f.UserId == testUser.UserId && f.EmailAddress == testFreindEmail);
            Assert.IsTrue(friendExists);

            context.Friends.Remove(context.Friends.FirstOrDefault(f => f.UserId == testUser.UserId && f.EmailAddress == testFreindEmail));
            context.SaveChanges();
        }
    }
}
