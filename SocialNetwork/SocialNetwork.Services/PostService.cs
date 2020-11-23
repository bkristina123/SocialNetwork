using Microsoft.AspNetCore.Http;
using SocialNetwork.Common.Helpers;
using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.ViewModelDTOs;
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


        public async Task CreatePost(User currentUser, HomepageViewDTO homepageViewDTO)
        {
            var post = new Post
            {
                Content = homepageViewDTO.CreatePost.Content,
                DateCreated = DateTime.Now,
                UserId = currentUser.Id
            };

            if (homepageViewDTO.CreatePost.Photo != null)
            {
                post.PhotoContent = await homepageViewDTO.CreatePost.Photo.ConvertImageToByte();
            }

            _postRepository.CreatePost(post);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _postRepository.GetAllPosts();
        }
    }
}
