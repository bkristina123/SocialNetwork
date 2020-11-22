using Microsoft.AspNetCore.Http;
using SocialNetwork.Common.Helpers;
using SocialNetwork.Data.Models;
using SocialNetwork.Repositories.Interfaces;
using SocialNetwork.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task CreatePost(User currentUser, string content, IFormFile photo)
        {
            if(content is null)
            {
                content = string.Empty;
            }

            var post = new Post
            {
                Content = content,
                DateCreated = DateTime.Now,
                UserId = currentUser.Id
            };

            if(photo != null)
            {
                post.PhotoContent = await photo.ConvertImageToByte();
            }

            _postRepository.CreatePost(post);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _postRepository.GetAllPosts();
        }
    }
}
