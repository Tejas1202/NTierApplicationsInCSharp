using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSightBook.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSightBook.IntegrationTests.Spikes.ActiveRecord
{
    [TestClass]
    class ActiveRecordTests
    {
        [TestMethod]
        public void CanCreateNewFriend()
        {
            Guid testUserId;
            using (var context = new aspnetdbEntities())
            {
                testUserId = context.aspnet_Membership.FirstOrDefault().UserId;
            }

            var friend = ActiveRecordFriend.CreateNew("steve@foo.com", testUserId);

            Assert.IsNotNull(friend);
        }

        [TestMethod]
        public void CanCreateExistingFriend()
        {
            Guid testUserId;
            using (var context = new aspnetdbEntities())
            {
                testUserId = context.aspnet_Membership.FirstOrDefault().UserId;
            }
            var friend = ActiveRecordFriend.CreateNew("steve@foo.com", testUserId);

            var secondFriend = new ActiveRecordFriend(friend.Id);

            Assert.IsNotNull(secondFriend);
        }

        [TestMethod]
        public void CanSaveChangesToFriend()
        {
            Guid testUserId;
            using (var context = new aspnetdbEntities())
            {
                testUserId = context.aspnet_Membership.FirstOrDefault().UserId;
            }
            var friend = ActiveRecordFriend.CreateNew("steve@foo.com", testUserId);

            var secondFriend = new ActiveRecordFriend(friend.Id);
            secondFriend.EmailAddress = "updated";
            secondFriend.Save();

            var thirdFriend = new ActiveRecordFriend(friend.Id);
            Assert.AreEqual(friend.EmailAddress, thirdFriend.EmailAddress);
        }

        /// <summary>
        /// This is needlessly difficult to set up and slower than it need be for just checking the business logic whether Domain is returned correctly or not
        /// </summary>
        [TestMethod]
        public void EmailDomainReturnedCorrectly()
        {
            Guid testUserId;
            using (var context = new aspnetdbEntities())
            {
                testUserId = context.aspnet_Membership.FirstOrDefault().UserId;
            }
            var friend = ActiveRecordFriend.CreateNew("steve@foo.com", testUserId);

            var domain = friend.EmailDomain;

            Assert.AreEqual("foo.com", domain);
        }

        // Here you can see that using the Friend domail model, we can easily test this Business Logic
        // (assume that this EmailDomain property is within the Friend class itself, derived a class here just for demo purpose and not to change logic in Friend model)
        public class PIFriend : Core.Models.Friend
        {
            public string EmailDomain
            {
                get
                {
                    return base.EmailAddress.Substring(base.EmailAddress.LastIndexOf('@') + 1);
                }
            }
        }

        [TestMethod]
        public void EmailDomainReturnedCorrectlyWithPIFriend()
        {
            var friend = new PIFriend() { EmailAddress = "steve@foo.com" };
            var domain = friend.EmailDomain;

            Assert.AreEqual("foo.com", domain);
        }
    }
}
