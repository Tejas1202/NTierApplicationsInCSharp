using PluralSightBook.Core.Models;
using System;
using System.Collections.Generic;

namespace PluralSightBook.Core.Interfaces
{
    public interface IFriendRepository
    {
        void Create(Guid userId, string emailAddress);

        void Delete(int friendId);

        IEnumerable<Friend> ListFriendsOfUser(Guid userId);
    }
}
