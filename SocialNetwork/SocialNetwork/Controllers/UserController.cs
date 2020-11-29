using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialNetwork.Common.Helpers;
using SocialNetwork.ModelDTOs.UserDTOs;
using SocialNetwork.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService,
            IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public IActionResult Edit(int id)
        {
            try
            {
                var sessionUser = _userService.GetSessionUser();

                var user = _userService.GetUserById(id)
                    .ConvertToEditUserDTO();

                if (sessionUser.Id != user.Id)
                {
                    return RedirectToAction("HomePage", "Home");
                }

                return View(user);
            }
            catch (Exception)
            {
                return StatusCode(int.Parse(_configuration["GlobalErrorCode"]));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserDTO editUserDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _userService.UpdateUser(editUserDTO);

                    if (!response.Succeeded)
                    {
                        foreach (var errorMessage in response.Errors)
                        {
                            ModelState.AddModelError(string.Empty, errorMessage.Description);
                        }

                        return View(editUserDTO);
                    }
                    return RedirectToAction("Profile", "Home", new { editUserDTO.Id });
                }

                return View(editUserDTO);
            }
            catch (Exception)
            {
                return StatusCode(int.Parse(_configuration["GlobalErrorCode"]));
            }
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit");
                }

                var response = await _userService.ChangePassword(changePasswordDTO);

                if (!response.Succeeded)
                {
                    foreach (var errorMessage in response.Errors)
                    {
                        ModelState.AddModelError(string.Empty, errorMessage.Description);
                    }

                    return View("Edit");
                }

                return View("Success");
            }
            catch (Exception)
            {
                return StatusCode(int.Parse(_configuration["GlobalErrorCode"]));
            }
        }
    }
}



