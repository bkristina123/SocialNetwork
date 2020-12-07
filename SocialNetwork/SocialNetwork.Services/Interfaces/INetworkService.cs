using SocialNetwork.Data.Models;
using System.Collections.Generic;

namespace SocialNetwork.Services.Interfaces
{
    public interface INetworkService
    {
        void SendFriendRequest(int targetUserId);
        IEnumerable<FriendRequest> GetFriendRequests();
    }
}
