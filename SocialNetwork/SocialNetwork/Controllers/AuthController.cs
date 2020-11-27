using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialNetwork.ModelDTOs.ActionResponse;
using SocialNetwork.Services.Interfaces;
using SocialNetwork.UserDTOs;
using System;
using System.Threading.Tasks;

namespace SocialNetwork.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService,
            IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [Route("/login")]
        public IActionResult Login()
        {
            try
            {
                var loginDTO = new LoginDTO();
                return View(loginDTO);
            }
            catch (Exception)
            {
                return StatusCode(int.Parse(_configuration["GlobalErrorCode"]));
            }
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SignInResponse response = await _authService.LoginUserAsync(loginDTO);

                    if (response.IsSuccesful)
                    {
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return LocalRedirect(returnUrl);
                        }
                        return RedirectToAction("HomePage", "Home");
                    }

                    ModelState.AddModelError(string.Empty, response.ErrorMessage);
                }

                return View(loginDTO);
            }
            catch (Exception)
            {
                return StatusCode(int.Parse(_configuration["GlobalErrorCode"]));
            }

        }

        [Route("/register")]
        public IActionResult Register()
        {
            try
            {
                var registerDTO = new RegisterDTO();
                return View(registerDTO);
            }
            catch (Exception)
            {
                return StatusCode(int.Parse(_configuration["GlobalErrorCode"]));
            }

        }


        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
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
            catch (Exception)
            {
                return StatusCode(int.Parse(_configuration["GlobalErrorCode"]));
            }

        }


        public async Task<IActionResult> Logout()
        {
            try
            {
                await _authService.LogoutAsync();
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                return StatusCode(int.Parse(_configuration["GlobalErrorCode"]));
            }
        }
    }
}