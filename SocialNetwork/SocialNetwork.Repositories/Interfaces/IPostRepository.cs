﻿using SocialNetwork.Data.Models;
using System.Collections.Generic;

namespace SocialNetwork.Repositories.Interfaces
{
    public interface IPostRepository
    {
        void CreatePost(Post post);
        IEnumerable<Post> GetAllPosts();
        List<Post> GetPostsForUser(int id);
        Post GetPostById(int id);
    }
}
