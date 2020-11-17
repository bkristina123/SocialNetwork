using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.ModelDTOs;
using SocialNetwork.ModelDTOs.ActionResponse;
using SocialNetwork.Services.Interfaces;
using System.Threading.Tasks;

namespace SocialNetwork.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("/login")]
        public IActionResult Login()
        
        {
            var loginDTO = new LoginDTO();
            return View(loginDTO);
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if(ModelState.IsValid)
            {
                SignInResponse response = await _authService.LoginUserAsync(loginDTO);

                if(response.IsSuccesful)
                {
                    return RedirectToAction("HomePage", "Home");
                }

                ModelState.AddModelError(string.Empty, response.ErrorMessage);
            }

            return View(loginDTO);
        }

        [Route("/register")]
        public IActionResult Register()
        {
            var registerDTO = new RegisterDTO();
            return View(registerDTO);
        }


        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            
            if(!ModelState.IsValid)
            {
                return View(registerDTO);
            }

            var result = await _authService.CreateUserAsync(registerDTO);

            if (!result.Succeeded)
            {
                foreach (var errorMessage in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, errorMessage.Description);
                }

                return View(registerDTO);
            }


            return RedirectToAction(nameof(Login));

        }
    }
}