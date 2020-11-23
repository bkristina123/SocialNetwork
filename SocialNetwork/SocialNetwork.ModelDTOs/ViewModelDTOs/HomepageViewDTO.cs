using SocialNetwork.ModelDTOs.PostDTOs;
using SocialNetwork.UserDTOs;
using System.Collections.Generic;

namespace SocialNetwork.ModelDTOs.ViewModelDTOs
{
    public class HomepageViewDTO
    {
        public HomepageUserDTO SessionUser { get; set; }
        public CreatePostDTO CreatePost { get; set; }
        public IEnumerable<ViewPostDTO> ViewPostList { get; set; }
    }
}
