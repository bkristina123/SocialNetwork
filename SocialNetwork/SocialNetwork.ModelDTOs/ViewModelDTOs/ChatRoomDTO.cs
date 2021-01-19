using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.UserDTOs;
using System.Collections.Generic;

namespace SocialNetwork.ModelDTOs.ViewModelDTOs
{
    public class ChatRoomDTO
    {
        public IEnumerable<ProfileUserDTO> ChatUsers { get; set; }
        public ChatRoom ChatRoom { get; set; }
        public User SessionUser { get; set; }
    }
}
