using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Models;
using PluralSightBook.Core.Services;
using System;
using System.Collections.Generic;

namespace PluralSightBook.UnitTests.Core
{
    [TestClass]
    public class FriendsService_ListFriendsOfShould
    {
        [TestMethod]
        public void ReturnListFromRepository()
        {
            var friendRepository = new Mock<IFriendRepository>();
            var notificationService = new Mock<INotificationService>();
            var myFriendsService = new FriendsService(notificationService.Object, friendRepository.Object);
            var testUserId = Guid.NewGuid();

            var result = myFriendsService.ListFriendsOf(testUserId);

            friendRepository.Verify(f => f.ListFriendsOfUser(testUserId));
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Friend>));
        }
    }
}
