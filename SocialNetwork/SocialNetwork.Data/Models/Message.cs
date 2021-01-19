using System;

namespace SocialNetwork.Data.Models
{
    public class Message
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Text { get; set; }

        public DateTime DateCreated { get; set; }

        public int ChatRoomId { get; set; }
        public ChatRoom ChatRoom { get; set; }
    }
}