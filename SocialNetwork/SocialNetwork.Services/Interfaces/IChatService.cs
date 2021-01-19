using SocialNetwork.Data.Models;

namespace SocialNetwork.Services.Interfaces
{
    public interface IChatService
    {
        ChatRoom CreateRoom(int userId);
        ChatRoom GetRoomForUsers(User sessionUser, User targetUser);
        ChatRoom GetChatRoomById(int chatRoomId);
        void AddMessage(string messageInput, int chatRoomId);
    }
}