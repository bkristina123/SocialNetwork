using SocialNetwork.Data.Models;
using SocialNetwork.Repositories.Interfaces;
using SocialNetwork.Services.Interfaces;
using System;
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

                var requestExists = CheckIfRequestIsSent(sessionUser.Id, targetUserId);

                if(!requestExists)
                {
                    _networkRepository.SendFriendRequest(request);
                }
                return;
            }
        }

        public bool CheckIfRequestIsSent(int sessionUserId, int targetUserId)
        {
            var requestCheckModel = _networkRepository.GetRequestForUsers(sessionUserId, targetUserId);

            if(requestCheckModel != null)
            {
                return true;
            }

            return false;
        }

        public void AcceptRequest(int requestId)
        {
            var request = _networkRepository.GetRequestById(requestId);

            var friendConnection = new FriendConnection
            {
                FirstUserId = request.FromUserId,
                SecondUserId = request.ToUserId
            };


            var areFriends = CheckIfFriends(request.FromUserId, request.ToUserId);

            if(!areFriends) {

                _networkRepository.AddFriendConnection(friendConnection);
                _networkRepository.DeleteFriendRequest(request);
            }

            return;
        }

        public void DeclineRequest(int requestId)
        {
            var request = _networkRepository.GetRequestById(requestId);
            _networkRepository.DeleteFriendRequest(request);
        }

        public bool CheckIfFriends(int firstUserId, int secondUserId)
        {
            var friendsCheckModel = _networkRepository.GetFriendConnectionForUsers(firstUserId, secondUserId);

            if(friendsCheckModel != null)
            {
                return true;
            }

            return false;
        }

        public IEnumerable<int> GetUserFriendsIds(User sessionUser)
        {

            var friendConnections = GetFriendConnectionsForSingeUser(sessionUser);

            var userIds = new List<int>();


            foreach (var connection in friendConnections)
            {
                if(connection.FirstUserId != sessionUser.Id)
                {
                    userIds.Add(connection.FirstUserId);
                }

                if(connection.SecondUserId != sessionUser.Id)
                {
                    userIds.Add(connection.SecondUserId);
                }
            }

            return userIds;
        }

        private IEnumerable<FriendConnection> GetFriendConnectionsForSingeUser(User user)
        {
            return _networkRepository.GetFriendConnectionsForSingleUser(user);
        }

        public IEnumerable<User> GetUserFriends(User user)
        {
            var userIds = GetUserFriendsIds(user);

            return _userService.GetUsersByIds(userIds);
        }
    }
}
