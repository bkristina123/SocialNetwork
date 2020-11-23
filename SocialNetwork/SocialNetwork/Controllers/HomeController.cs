using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Common.Helpers;
using SocialNetwork.ModelDTOs.PostDTOs;
using SocialNetwork.ModelDTOs.ViewModelDTOs;
using SocialNetwork.Services.Interfaces;
using System.Linq;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public HomeController(IPostService postService,
            IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        public IActionResult HomePage()
        {
            var homepageViewModel = new HomepageViewDTO();

            homepageViewModel.SessionUser = _userService.GetSessionUser()
                .ConvertToHomepageUserDTO();

            homepageViewModel.CreatePost = new CreatePostDTO();

            homepageViewModel.ViewPostList = _postService.GetAllPosts()
                .Select(x => x.ConvertToViewPostDTO())
                .ToList();

            return View(homepageViewModel);

        }
    }
}
