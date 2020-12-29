using SocialNetwork.Data.Models;
using System.Collections.Generic;

namespace SocialNetwork.Repositories.Interfaces
{
    public interface INetworkRepository
    {
        void SendFriendRequest(FriendRequest request);
        IEnumerable<FriendRequest> GetFriendRequests(User sessionUser);
        FriendRequest GetRequestForUsers(int sessionUserId, int targetUserId);
        void DeleteFriendRequest(FriendRequest request);
        FriendRequest GetRequestById(int requestId);
        void AddFriendConnection(FriendConnection friendConnection);
        FriendConnection GetFriendConnectionForUsers(int firstUserId, int secondUserId);
        IEnumerable<FriendConnection> GetFriendConnectionsForSingleUser(User sessionUser);
        void RemoveFriendConnection(FriendConnection friendConnection);
    }
}
