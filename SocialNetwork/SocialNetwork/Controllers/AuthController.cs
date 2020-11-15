using Microsoft.AspNetCore.Mvc;
using SocialNetwork.ModelDTOs;

namespace SocialNetwork.Controllers
{
    public class AuthController : Controller
    {
        [Route("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/register")]
        public IActionResult Register()
        {
            var registerDTO = new RegisterDTO();
            return View(registerDTO);
        }


        [HttpPost]
        [Route("/register")]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                //do register logic
                return View();

            }

            return View(registerDTO);
        }
    }
}