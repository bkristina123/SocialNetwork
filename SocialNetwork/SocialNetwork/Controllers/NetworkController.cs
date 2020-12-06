using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class NetworkController : Controller
    {

        [Route("/network")]
        public IActionResult ManageNetwork()
        {
            return View();
        }
    }
}