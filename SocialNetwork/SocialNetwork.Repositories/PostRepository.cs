using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts
                .Include(x => x.User)
                .OrderByDescending(x => x.DateCreated)
                .ToList();
        }

        public List<Post> GetPostsForUser(int id)
        {
            return _context.Posts
                .Include(x => x.User)
                .OrderByDescending(x => x.DateCreated)
                .Where(x => x.UserId.Equals(id))
                .ToList();
        }
    }
}
