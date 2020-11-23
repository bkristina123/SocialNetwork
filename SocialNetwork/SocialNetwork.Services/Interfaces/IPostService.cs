using Microsoft.AspNetCore.Http;
using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.ViewModelDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IPostService
    {
        Task CreatePost(User currentUser, HomepageViewDTO homepageViewDTO);
        IEnumerable<Post> GetAllPosts();
    }
}
