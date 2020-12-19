using SocialNetwork.Data.Enums;
using SocialNetwork.ModelDTOs.PostDTOs;
using System.Collections.Generic;

namespace SocialNetwork.ModelDTOs.UserDTOs
{
    public class ProfileUserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhoto { get; set; }
        public List<ViewPostDTO> Posts { get; set; }
        public RelationType UsersRelation { get; set; }
    }
}
