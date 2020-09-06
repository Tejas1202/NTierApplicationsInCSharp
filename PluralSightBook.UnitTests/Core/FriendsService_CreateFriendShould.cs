using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSightBook.UnitTests.Core
{
    [TestClass]
    class FriendsService_CreateFriendShould
    {
        [TestMethod]
        public void CreateFriendAndSendNotification()
        {
            var notificationService = new Mock<INotificationService>();
            var friendsRepository = new Mock<IFriendRepository>();
            var friendsService = new FriendsService(notificationService.Object, friendsRepository.Object);

            friendsService.AddFriend(Guid.NewGuid(), "", "", "");

            friendsRepository.Verify(f => f.Create(It.IsAny<Guid>(), It.IsAny<string>()));
            notificationService.Verify(n => n.SendNotification(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        }
    }
}
