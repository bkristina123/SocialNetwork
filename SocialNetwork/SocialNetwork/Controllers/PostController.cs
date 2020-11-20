using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class PostController : Controller
    {
        public IActionResult CreatePost()
        {
            return RedirectToAction("HomePage", "Home");
        }
    }
}