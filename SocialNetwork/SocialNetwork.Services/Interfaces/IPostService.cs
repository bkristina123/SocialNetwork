using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.ActionResponse;
using SocialNetwork.ModelDTOs.ViewModelDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IPostService
    {
        Task<PostResponse> CreatePost(User currentUser, HomepageViewDTO homepageViewDTO);
        IEnumerable<Post> GetAllPosts();
        List<Post> GetPostsForUser(int id);
        Post GetPostById(int id);
    }
}
