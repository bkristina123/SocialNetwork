using System.Collections.Generic;

namespace SocialNetwork.Data.Models
{
    public class ChatRoom
    {
        public ChatRoom()
        {
            Users = new List<User>();
        }


        public int Id { get; set; }

        public ICollection<Message> Messages  { get; set; }
        public ICollection<User> Users { get; set; }
        public string Name { get; set; }

    }
}
