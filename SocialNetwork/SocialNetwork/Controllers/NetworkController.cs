using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Common.Helpers;
using SocialNetwork.ModelDTOs.ViewModelDTOs;
using SocialNetwork.Services.Interfaces;
using System;
using System.Linq;

namespace SocialNetwork.Controllers
{
    public class NetworkController : Controller
    {
        private readonly INetworkService _networkService;
        private readonly IUserService _userService;

        public NetworkController(INetworkService networkService,
            IUserService userService)
        {
            _networkService = networkService;
            _userService = userService;
        }

        [Route("/network")]
        public IActionResult ManageNetwork()
        {
            try
            {
                var sessionUser = _userService.GetSessionUser();
                var requests = _networkService.GetFriendRequests();
                var users = _networkService.GetUserFriends(sessionUser)
                    .Select(x => x.ConvertToProfileUserDTO());
                var manageNetworkViewDTO = new ManageNetworkViewDTO
                {
                    FriendRequests = requests,
                    UserFriends = users
                };

                return View(manageNetworkViewDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        public IActionResult SendFriendRequest(int targetUserId)
        {
            try
            {
                _networkService.SendFriendRequest(targetUserId);
                return RedirectToAction("Profile", "Home", new { Id = targetUserId });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public IActionResult AcceptRequest(int requestId)
        {
            _networkService.AcceptRequest(requestId);
            return RedirectToAction(nameof(ManageNetwork));
        }

        public IActionResult DeclineRequest(int requestId)
        {
            _networkService.DeclineRequest(requestId);
            return RedirectToAction(nameof(ManageNetwork));
        }
    }
}