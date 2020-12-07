using SocialNetwork.Data.Models;
using System.Collections.Generic;

namespace SocialNetwork.Repositories.Interfaces
{
    public interface INetworkRepository
    {
        void SendFriendRequest(FriendRequest request);
        IEnumerable<FriendRequest> GetFriendRequests(User sessionUser);
    }
}
