using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Common.Helpers;
using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.ViewModelDTOs;
using SocialNetwork.Services.Interfaces;
using System.Linq;

namespace SocialNetwork.Controllers
{
    public class ChatController : Controller
    {
        private readonly INetworkService _networkService;
        private readonly IUserService _userService;
        private readonly IChatService _chatService;

        public ChatController(INetworkService networkService,
            IUserService userService,
            IChatService chatService)
        {
            _networkService = networkService;
            _userService = userService;
            _chatService = chatService;
        }

        public IActionResult Overview(int chatRoomId)
        {
            var sessionUser = _userService.GetSessionUser();
            ChatRoomDTO chatOverviewDTO = _chatService.CreateChatRoomDTO(chatRoomId, sessionUser);

            return View(chatOverviewDTO);
        }
        

        public IActionResult CreateRoom(int userId)
        {
            var room = _chatService.CreateRoom(userId);

            return RedirectToAction("Overview", "Chat", new { chatRoomId = room.Id });
        }

        [HttpPost]
        public IActionResult AddMessage(string messageInput, int chatRoomId)
        {
            _chatService.AddMessage(messageInput, chatRoomId);
            return RedirectToAction("Overview", "Chat", new { chatRoomId });
        }
    }
}