using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Services;

namespace PluralSightBook.UnitTests.Core
{
    [TestClass]
    class FriendsService_DeleteFriendShould
    {
        [TestMethod]
        public void DeleteFriendViaRepository()
        {
            var notificationService = new Mock<INotificationService>();
            var friendRepository = new Mock<IFriendRepository>();
            var friendsService = new FriendsService(notificationService.Object, friendRepository.Object);

            friendsService.DeleteFriend(0);

            friendRepository.Verify(f => f.Delete(0));
        }
    }
}
