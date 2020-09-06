using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Services;
using System;

namespace PluralSightBook.UnitTests.Core
{
    [TestClass]
    public class NotificationService_SendNotificationShould
    {
        private Mock<IQueryUsersByEmail> _queryUsersByEmail;
        private Mock<ISendEmail> _emailSender;

        [TestInitialize]
        public void SetUp()
        {
            _queryUsersByEmail = new Mock<IQueryUsersByEmail>();
            _emailSender = new Mock<ISendEmail>();
        }

        [TestMethod]
        public void SendCorrectEmailWhenAlreadyFriends()
        {
            var myNotificationService = new NotificationService(_queryUsersByEmail.Object, _emailSender.Object);
            _queryUsersByEmail.Setup(q => q.UserWithEmailExists(It.IsAny<string>())).
                Returns(true);
            _queryUsersByEmail.Setup(q => q.GetUserByEmail(It.IsAny<string>())).
                Returns(new PluralSightBook.Core.Models.User());
            _queryUsersByEmail.Setup(q => q.IsUserWithEmailFriendOfUser(It.IsAny<Guid>(), It.IsAny<string>())).
                Returns(true);

            myNotificationService.SendNotification("abc", "def", "ghi");

            string expectedBody = string.Format(@"Good News! friend {0} just added you as a friend!", "abc");
            _emailSender.Verify(e => e.SendEmail(expectedBody));
        }

        [TestMethod]
        public void SendCorrectEmailWhenMemberButNotFriend()
        {
            var myNotificationService = new NotificationService(_queryUsersByEmail.Object, _emailSender.Object);
            _queryUsersByEmail.Setup(q => q.UserWithEmailExists(It.IsAny<string>())).
                Returns(true);
            _queryUsersByEmail.Setup(q => q.GetUserByEmail(It.IsAny<string>())).
                Returns(new PluralSightBook.Core.Models.User());
            _queryUsersByEmail.Setup(q => q.IsUserWithEmailFriendOfUser(It.IsAny<Guid>(), It.IsAny<string>())).
                Returns(false);

            myNotificationService.SendNotification("abc", "def", "ghi");

            string expectedBody = String.Format(@"{0} added you as a friend on PluralsightBook!  Click here to add them as your friend:
                                http://localhost:4927/QuickAddFriend.aspx?email={1}",
                                "def",
                                "abc");
            _emailSender.Verify(s => s.SendEmail(expectedBody));
        }

        [TestMethod]
        public void SendCorrectEmailWhenNotMember()
        {
            _queryUsersByEmail.Setup(q => q.UserWithEmailExists(It.IsAny<string>())).Returns(false);
            var notificationService = new NotificationService(_queryUsersByEmail.Object, _emailSender.Object);

            notificationService.SendNotification("abc", "def", "ghi");

            string exprectBody = String.Format(@"{0} added you as a friend on PluralsightBook!  Click here to register your own account and then add them as your friend: http://localhost:4927/QuickAddFriend.aspx?email={1}",
                                    "def", "abc");
            _emailSender.Verify(s => s.SendEmail(exprectBody));                        
        }
    }
}
