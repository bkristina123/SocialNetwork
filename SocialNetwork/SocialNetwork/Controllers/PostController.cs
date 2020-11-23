using Microsoft.AspNetCore.Mvc;
using SocialNetwork.ModelDTOs.ViewModelDTOs;
using SocialNetwork.Services.Interfaces;

namespace SocialNetwork.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public PostController(IPostService postService,
            IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreatePost(HomepageViewDTO homepageViewDTO)
        {

            var currentUser = _userService.GetSessionUser();

            //fix image size problem
            //fix empty posts
            _postService.CreatePost(currentUser, homepageViewDTO);

            return RedirectToAction("HomePage", "Home");
        }
    }
}