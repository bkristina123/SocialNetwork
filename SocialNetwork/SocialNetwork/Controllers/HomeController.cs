using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Common.Helpers;
using SocialNetwork.Data.Enums;
using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.UserDTOs;
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
        private readonly INetworkService _networkService;

        public HomeController(IPostService postService,
            IUserService userService,
            INetworkService networkService)
        {
            _postService = postService;
            _userService = userService;
            _networkService = networkService;
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
                var targetUser = _userService.GetUserById(id);

                if (targetUser is null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                var sessionUser = _userService.GetSessionUser();
                var requestIsSent = _networkService.CheckIfRequestIsSent(targetUser.Id, sessionUser.Id);
                var areFriends = _networkService.CheckIfFriends(targetUser.Id, sessionUser.Id);


                var userDTO = targetUser.ConvertToProfileUserDTO();
                userDTO.Posts = _postService.GetPostsOfUser(targetUser.Id).
                    Select(x => x.ConvertToViewPostDTO())
                    .ToList();

                RegulateUserType(targetUser, sessionUser, userDTO, requestIsSent, areFriends);

                return View(userDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        private static void RegulateUserType(User targetUser, User sessionUser, ProfileUserDTO userDTO, bool requestIsSent, bool areFriends)
        {

            if (targetUser.Equals(sessionUser))
            {
                userDTO.UsersRelation = RelationType.isSessionUser;
            }
            else if (requestIsSent)
            {
                userDTO.UsersRelation = RelationType.isRequested;
            }
            else if(areFriends) {

                userDTO.UsersRelation = RelationType.isFriend;
            }
            else
            {
                userDTO.UsersRelation = RelationType.isNotFriend;
            }
        }
    }   
}
