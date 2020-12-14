using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialNetwork.ModelDTOs.ViewModelDTOs;
using SocialNetwork.Services.Interfaces;
using System;

namespace SocialNetwork.Controllers
{
    public class NetworkController : Controller
    {
        private readonly INetworkService _networkService;

        public NetworkController(INetworkService networkService)
        {
            _networkService = networkService;
        }

        [Route("/network")]
        public IActionResult ManageNetwork()
        {
            try
            {
                var requests = _networkService.GetFriendRequests();
                var manageNetworkViewDTO = new ManageNetworkViewDTO
                {
                    FriendRequests = requests
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
    }
}