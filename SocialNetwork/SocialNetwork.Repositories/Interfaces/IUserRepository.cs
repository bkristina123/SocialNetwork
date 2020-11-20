using SocialNetwork.Data.Models;

namespace SocialNetwork.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
    }
}
