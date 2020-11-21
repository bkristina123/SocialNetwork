using SocialNetwork.Data;
using SocialNetwork.Repositories.Interfaces;

namespace SocialNetwork.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
