using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Common.Helpers;
using SocialNetwork.ModelDTOs.ViewModelDTOs;
using SocialNetwork.Services.Interfaces;
using System;
using System.Linq;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public HomeController(IPostService postService,
            IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        public IActionResult HomePage()
        {
            try
            {
                var homepageViewModel = new HomepageViewDTO();

                homepageViewModel.SessionUser = _userService.GetSessionUser()
                    .ConvertToHomepageUserDTO();

                homepageViewModel.ViewPostList = _postService.GetAllPosts()
                    .Select(x => x.ConvertToViewPostDTO())
                    .ToList();

                return View(homepageViewModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }


        [Route("profile/{id}")]
        public IActionResult Profile(int id)
        {

            try
            {
                var user = _userService.GetUserById(id);

                if (user is null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                var userDTO = user.ConvertToProfileUserDTO();
                userDTO.Posts = _postService.GetPostsOfUser(user.Id).
                    Select(x => x.ConvertToViewPostDTO())
                    .ToList();

                return View(userDTO);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

    }   
}
