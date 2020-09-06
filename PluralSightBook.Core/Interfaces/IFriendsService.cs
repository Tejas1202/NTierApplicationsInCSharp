using PluralSightBook.Core.Models;
using System;
using System.Collections.Generic;

namespace PluralSightBook.Core.Interfaces
{
    public interface IFriendsService
    {
        void AddFriend(Guid currentUserId, string currentUserEmail, string currentUserName, string friendEmail);
        void DeleteFriend(int friendId);
        IEnumerable<Friend> ListFriendsOf(Guid userId);
    }
}