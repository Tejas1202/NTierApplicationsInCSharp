using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSightBook.Data;
using PluralSightBook.Data.Models;
using PluralSightBook.IntegrationTests.Spikes.CodeFirst;
using System.Linq;

namespace PluralSightBook.IntegrationTests.Spikes.Repositories
{
    [TestClass]
    public class GenericRepoTests
    {
        [TestMethod]
        public void AddFriendUsingGenericRepo()
        {
            using (var context = new PluralSightBookContext())
            {
                var initializer = new TestDbInitializer();
                initializer.Reseed(context);

                int friendCount = context.Friends.Count();
                var testUserId = context.aspnet_Users
                    .FirstOrDefault(u => u.UserName == TestDbInitializer.TEST_USERNAME)
                    .UserId;

                var repo = new Repositories.Repository<Friend>();
                repo.Add(new Friend() { UserId = testUserId, EmailAddress = "somebody@somewhere.com" });
                repo.Save();

                Assert.AreEqual(friendCount + 1, context.Friends.Count());
            }
        }

        [TestMethod]
        public void DeleteFriendUsingGenericRepo()
        {
            using (var context = new PluralSightBookContext())
            {
                var initializer = new TestDbInitializer();
                initializer.Reseed(context);

                int friendCount = context.Friends.Count();
                var testUserId = context.aspnet_Users.FirstOrDefault().UserId;

                var repo = new Repositories.Repository<Friend>(context);
                var friend = new Friend() { UserId = testUserId, EmailAddress = "somebody@somewhere.com" };
                repo.Add(friend);
                repo.Save();

                // Hence always use the same context while saving and deleting the same object/entity
                // Fails because we're using a different object context
                //var repo2 = new Repositories.Repository<Friend>();
                var repo2 = new Repositories.Repository<Friend>(context);
                repo2.Remove(friend);
                repo2.Save();

                Assert.AreEqual(friendCount, context.Friends.Count());
            }
        }

        [TestMethod]
        public void WhyNotExposeIQueryable()
        {
            using (var context = new PluralSightBookContext())
            {
                var initializer = new TestDbInitializer();
                initializer.Reseed(context);

                var friendRepo = new QueryableFriendRepo(context);
                var testUserId = context.aspnet_Users.FirstOrDefault().UserId;

                // populate some friend sample data
                friendRepo.Add(new Friend() { UserId = testUserId, EmailAddress = "user@foo.com" });
                friendRepo.Add(new Friend() { UserId = testUserId, EmailAddress = "anotheruser@foo.com" });
                friendRepo.Add(new Friend() { UserId = testUserId, EmailAddress = "user@microsoft.com" });
                friendRepo.Save();

                var result = friendRepo.List().Where(f => f.EmailAddress.Contains("foo"));

                Assert.AreEqual(2, result.Count());

                // this tries to run a query on the database but can't
                //var moreResults = friendRepo.List()
                //    .Where(f => f.IsMicrosoftEmployee());
                //foreach (var res in moreResults)
                //{
                //    Console.WriteLine(res);
                //}
                //Assert.AreEqual(1, moreResults.Count());

                // using IEnumerable works as expected, but may fetch more data than desired
                // however, it never will *surprise* the developer with whether they are working
                // with the database or not
                var nonQueryableRepo = new Repository<Friend>(context);
                var msFriends = nonQueryableRepo.GetAll()
                    .Where(f => f.IsMicrosoftEmployee());

                Assert.AreEqual(1, msFriends.Count());
            }
        }
    }

    public static class FriendExtensions
    {
        public static bool IsMicrosoftEmployee(this Friend friend)
        {
            return friend.EmailAddress.Contains("microsoft.com");
        }
    }
}
