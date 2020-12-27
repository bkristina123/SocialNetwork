using SocialNetwork.Data.Models;
using System.Collections.Generic;

namespace SocialNetwork.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        IEnumerable<User> GetUsersByIds(IEnumerable<int> userIds);
    }
}
