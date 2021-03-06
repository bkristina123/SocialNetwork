﻿using SocialNetwork.Data.Models;
using System.Collections.Generic;

namespace SocialNetwork.Services.Interfaces
{
    public interface INetworkService
    {
        void SendFriendRequest(int targetUserId);
        IEnumerable<FriendRequest> GetFriendRequests();
        bool CheckIfRequestIsSent(int sessionUserId, int targetUserId);
        void AcceptRequest(int requestId);
        void DeclineRequest(int requestId);
        bool CheckIfFriends(int firstUserId, int secondUserId);
        IEnumerable<int> GetUserFriendsIds(User user);
        IEnumerable<User> GetUserFriends(User user);
        void RemoveFriend(int id);
    }
}
