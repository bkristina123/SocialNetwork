using SocialNetwork.Data.Models;
using SocialNetwork.Repositories.Interfaces;
using SocialNetwork.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserService _userService;

        public ChatService(IChatRepository chatRepository,
            IUserService userService)
        {
            _chatRepository = chatRepository;
            _userService = userService;
        }

        public void AddMessage(string messageInput, int chatRoomId)
        {
            var sessionUser = _userService.GetSessionUser();

            var message = new Message
            {
                Text = messageInput,
                ChatRoomId = chatRoomId,
                UserId = sessionUser.Id,
                DateCreated = DateTime.Now
            };

            _chatRepository.AddMessage(message);
        }

        public ChatRoom CreateRoom(int userId)
        {
            var sessionUser = _userService.GetSessionUser();
            var targetUser = _userService.GetUserById(userId);
            var users = new List<User> {sessionUser, targetUser};

            //fix creation of many rooms
            var dbRoom = GetRoomForUsers(sessionUser, targetUser);

            if(dbRoom is null)
            {

                var chatRoom = new ChatRoom()
                {
                    Users = users,
                    Name = targetUser.FirstName,
                };

                _chatRepository.AddRoom(chatRoom);

                return chatRoom;
            }

            return dbRoom;
        }

        public ChatRoom GetChatRoomById(int chatRoomId)
        {
            return _chatRepository.GetChatRoomById(chatRoomId);
        }

        public ChatRoom GetRoomForUsers(User sessionUser, User targetUser)
        {
           return _chatRepository.GetRoomForUsers(sessionUser, targetUser);
        }
    }
}
