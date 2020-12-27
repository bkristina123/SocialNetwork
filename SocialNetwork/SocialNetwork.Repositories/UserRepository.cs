using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using System.Collections.Generic;
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

        public IEnumerable<User> GetUsersByIds(IEnumerable<int> userIds)
        {
            return _context.Users
                .Where(x => userIds.Contains(x.Id));
        }
    }
}
