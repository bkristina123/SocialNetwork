using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Repositories.Interfaces;
using System.Linq;

namespace SocialNetwork.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _context;

        public ChatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public void AddRoom(ChatRoom chatRoom)
        {
            _context.ChatRooms.Add(chatRoom);
            _context.SaveChanges();
        }

        public ChatRoom GetChatRoomById(int chatRoomId)
        {
            return _context.ChatRooms
                .Include(x => x.Messages)
                .FirstOrDefault(x => x.Id.Equals(chatRoomId));
        }

        public ChatRoom GetRoomForUsers(User sessionUser, User targetUser)
        {
            return _context.ChatRooms.FirstOrDefault(x =>
            x.Users.Contains(sessionUser) &&
            x.Users.Contains(targetUser));
        }
    }
}
