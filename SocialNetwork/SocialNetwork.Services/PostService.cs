﻿using SocialNetwork.Common.Helpers;
using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.ActionResponse;
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


        public async Task<PostResponse> CreatePost(User currentUser, HomepageViewDTO homepageViewDTO)
        {

            var postResponse = new PostResponse();

            if(homepageViewDTO.CreatePost.Content is null && 
                homepageViewDTO.CreatePost.Photo is null)
            {
                postResponse.ErrorMessage = "You must enter at least one of the fields";
                return postResponse;
            }

            if (homepageViewDTO.CreatePost.Content is null)
            {
                homepageViewDTO.CreatePost.Content = string.Empty;
            }

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
            postResponse.IsSuccesful = true;
            return postResponse;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _postRepository.GetAllPosts();
        }

        public Post GetPostById(int id)
        {
            return _postRepository.GetPostById(id);
        }

        public List<Post> GetPostsOfUser(int id)
        {
            return _postRepository.GetPostsForUser(id);
        }
    }
}
