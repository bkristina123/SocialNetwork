using SocialNetwork.Data.Models;
using System.Collections.Generic;

namespace SocialNetwork.ModelDTOs.UserDTOs
{
    public class ProfileUserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhoto { get; set; }
        public List<Post> Posts { get; set; }
    }
}
