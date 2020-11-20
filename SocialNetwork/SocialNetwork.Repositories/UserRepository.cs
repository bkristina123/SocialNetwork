using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using System.Linq;

namespace SocialNetwork.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public User GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault( x => x.Id.Equals(id));

            return user;
        }
    }
}
