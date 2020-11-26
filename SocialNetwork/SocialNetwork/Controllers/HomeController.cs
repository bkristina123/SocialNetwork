using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Common.Helpers;
using SocialNetwork.ModelDTOs.ViewModelDTOs;
using SocialNetwork.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

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

            homepageViewModel.ViewPostList = _postService.GetAllPosts()
                .Select(x => x.ConvertToViewPostDTO())
                .ToList();

            return View(homepageViewModel);

        }


        [Route("profile/{id}")]
        public IActionResult Profile(int id)
        {

            var user = _userService.GetUserById(id);

            if (user is null)
            {
                return RedirectToAction(nameof(PageNotFound));
            }

            var userDTO = user.ConvertToProfileUserDTO();
            userDTO.Posts = _postService.GetPostsForUser(user.Id).
                Select(x => x.ConvertToViewPostDTO())
                .ToList();

            return View(userDTO);
        }

        [AllowAnonymous]
        [Route("/pagenotfound")]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
