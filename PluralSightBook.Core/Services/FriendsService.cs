using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Models;
using System;
using System.Collections.Generic;

namespace PluralSightBook.Core.Services
{
    public class FriendsService : IFriendsService
    {
        private readonly INotificationService _notificationService;
        private readonly IFriendRepository _friendRepository;
        public FriendsService(INotificationService notificationService, IFriendRepository friendRepository)
        {
            _notificationService = notificationService;
            _friendRepository = friendRepository;
        }

        public void AddFriend(Guid currentUserId, string currentUserEmail, string currentUserName, string friendEmail)
        {
            _friendRepository.Create(currentUserId, friendEmail);

            _notificationService.SendNotification(currentUserEmail, currentUserName, friendEmail);
        }

        public IEnumerable<Friend> ListFriendsOf(Guid userId)
        {
            return _friendRepository.ListFriendsOfUser(userId);
        }

        public void DeleteFriend(int friendId)
        {
            _friendRepository.Delete(friendId);
        }

    }
}
