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
        private readonly IConfiguration _configuration;

        public NetworkController(INetworkService networkService,
            IConfiguration configuration)
        {
            _networkService = networkService;
            _configuration = configuration;
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
                return StatusCode(int.Parse(_configuration["GlobalErrorCode"]));
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
                return StatusCode(int.Parse(_configuration["GlobalErrorCode"]));
            }
        }
    }
}