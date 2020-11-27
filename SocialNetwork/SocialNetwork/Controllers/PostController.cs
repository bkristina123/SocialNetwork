using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialNetwork.ModelDTOs.ViewModelDTOs;
using SocialNetwork.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace SocialNetwork.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public PostController(IPostService postService,
            IUserService userService,
            IConfiguration configuration)
        {
            _postService = postService;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(HomepageViewDTO homepageViewDTO)
        {
            try
            {
                var currentUser = _userService.GetSessionUser();

                //fix image size problem
                var postResponse = await _postService.CreatePost(currentUser, homepageViewDTO);

                if (!postResponse.IsSuccesful)
                {
                    TempData["Error"] = postResponse.ErrorMessage;
                }

                return RedirectToAction("HomePage", "Home");
            }
            catch (Exception)
            {
                return StatusCode(int.Parse(_configuration["GlobalErrorCode"]));
            }

        }
    }
}