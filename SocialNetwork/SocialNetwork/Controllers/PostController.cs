using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Common.Helpers;
using SocialNetwork.ModelDTOs.ViewModelDTOs;
using SocialNetwork.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public PostController(IPostService postService,
            IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(HomepageViewDTO homepageViewDTO)
        {

            var currentUser = _userService.GetSessionUser();

            //fix image size problem
            var postResponse = await _postService.CreatePost(currentUser, homepageViewDTO);

            if(!postResponse.IsSuccesful)
            {
                TempData["Error"] = postResponse.ErrorMessage;
            }

            return RedirectToAction("HomePage", "Home");
        }
    }
}