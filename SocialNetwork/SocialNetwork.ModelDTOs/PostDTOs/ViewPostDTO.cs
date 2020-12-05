using System;

namespace SocialNetwork.ModelDTOs.PostDTOs
{
    public class ViewPostDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserProfilePhoto { get; set; }
        public string PhotoContent { get; set; }
        public string TextContent { get; set; } 
        public DateTime DateCreated { get; set; }
    }
}
