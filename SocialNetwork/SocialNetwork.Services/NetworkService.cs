using SocialNetwork.Data.Models;
using SocialNetwork.Repositories.Interfaces;
using SocialNetwork.Services.Interfaces;
using System.Collections.Generic;

namespace SocialNetwork.Services
{
    public class NetworkService : INetworkService
    {
        private readonly INetworkRepository _networkRepository;
        private readonly IUserService _userService;

        public NetworkService(INetworkRepository networkRepository,
            IUserService userService)
        {
            _networkRepository = networkRepository;
            _userService = userService;
        }

        public IEnumerable<FriendRequest> GetFriendRequests()
        {
            var sessionUser = _userService.GetSessionUser();

            return _networkRepository.GetFriendRequests(sessionUser);
        }

        public void SendFriendRequest(int targetUserId)
        {
            var sessionUser = _userService.GetSessionUser();

            var request = new FriendRequest
            {
                FromUserId = sessionUser.Id,
                ToUserId = targetUserId
            };

            _networkRepository.SendFriendRequest(request);
        }
    }
}
