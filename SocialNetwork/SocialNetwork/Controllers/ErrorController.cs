using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult GlobalError()
        {
            return View();
        }

        [Route("/Error/{statusCode}")]
        public IActionResult StatusCodeError(int statusCode)
        {

            if(statusCode.Equals(404))
            {
                TempData["ErrorMessage"] = "404 Page Not Found";
            } else
            {
                return View("GlobalError");
            }

            return View();

        }
    }
}