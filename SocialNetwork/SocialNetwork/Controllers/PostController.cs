using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Services.Interfaces;
using System.Security.Claims;

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

        public IActionResult CreatePost(string content, IFormFile photo)
        {

            var currentUser = _userService.GetUserById(int.Parse(User.
                FindFirst(ClaimTypes.NameIdentifier)
                .Value));

            _postService.CreatePost(currentUser, content, photo);

            return RedirectToAction("HomePage", "Home");
        }
    }
}