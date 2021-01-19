using SocialNetwork.Data.Models;

namespace SocialNetwork.Repositories.Interfaces
{
    public interface IChatRepository
    {
        void AddRoom(ChatRoom chatRoom);
        ChatRoom GetRoomForUsers(User sessionUser, User targetUser);
        ChatRoom GetChatRoomById(int chatRoomId);
        void AddMessage(Message message);
    }
}