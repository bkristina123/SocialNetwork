using Microsoft.AspNetCore.Http;

namespace SocialNetwork.ModelDTOs.PostDTOs
{
    public class CreatePostDTO
    {
        public IFormFile Photo { get; set; }
        public string Content { get; set; }
    }
}
