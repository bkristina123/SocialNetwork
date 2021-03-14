using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.ViewModelDTOs;

namespace SocialNetwork.Services.Interfaces
{
    public interface IChatService
    {
        ChatRoom CreateRoom(int userId);
        ChatRoom GetRoomForUsers(User sessionUser, User targetUser);
        ChatRoom GetChatRoomById(int chatRoomId);
        ChatRoomDTO CreateChatRoomDTO(int chatRoomId, User sessionUser);
        void AddMessage(string messageInput, int chatRoomId);
    }
}