using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Overview()
        {
            return View();
        }
    }
}