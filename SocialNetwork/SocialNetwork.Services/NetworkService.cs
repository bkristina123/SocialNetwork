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
            {
                var request = new FriendRequest
                {
                    FromUserId = sessionUser.Id,
                    ToUserId = targetUserId
                };

                var relationExists = CheckFriendRelation(sessionUser.Id, targetUserId);

                if(!relationExists)
                {
                    _networkRepository.SendFriendRequest(request);
                }
                return;
            }
        }

        private bool CheckFriendRelation(int sessionUserId, int targetUserId)
        {
            var requestCheckModel = _networkRepository.GetRequestForUsers(sessionUserId, targetUserId);

            if(requestCheckModel != null)
            {
                return true;
            }

            return false;
        }
    }
}
