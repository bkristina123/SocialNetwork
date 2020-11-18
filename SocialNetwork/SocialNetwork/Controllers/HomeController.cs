using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Common.Helpers;
using SocialNetwork.Services.Interfaces;
using System.Security.Claims;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult HomePage()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var currentUser = _userService.GetUserById(int.Parse(currentUserId))
                .ConvertToHomepageUserDTO();

            return View(currentUser);
        }
    }
}
