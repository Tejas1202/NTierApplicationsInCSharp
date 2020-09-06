using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PluralSightBook.IntegrationTests.Spikes.Mapping
{
    [TestClass]
    public class RepoMappingTests
    {
        [TestMethod]
        public void ListFriendsUsingMapper()
        {
            var mappingFriendRepository = new MappingFriendRepository();
            var testUserId = Guid.Empty;
            using (var context = new aspnetdbEntities())
            {
                testUserId = context.aspnet_Membership.FirstOrDefault().UserId;
            }

            var result = mappingFriendRepository.ListFriendsOfUser(testUserId);

            Assert.IsInstanceOfType(result.FirstOrDefault(), typeof(Core.Models.Friend));
        }
    }

    public class MappingFriendRepository : IFriendRepository
    {
        public void Create(Guid userId, string emailAddress)
        {
            throw new NotImplementedException();
        }

        public void Delete(int friendId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Models.Friend> ListFriendsOfUser(Guid userId)
        {
            var context = new aspnetdbEntities();

            return context.Friends.Where(f => f.UserId == userId).
                ToList().
                Select(f => Mapper.Map<Core.Models.Friend>(f));
        }
    }
}
