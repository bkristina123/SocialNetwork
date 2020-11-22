using Microsoft.AspNetCore.Http;
using SocialNetwork.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IPostService
    {
        Task CreatePost(User currentUser, string content, IFormFile photo);
        IEnumerable<Post> GetAllPosts();
    }
}
