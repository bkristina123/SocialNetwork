using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Services.Interfaces;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult HomePage()
        {
            var posts = _postService.GetAllPosts();

            return View(posts);

        }
    }
}
