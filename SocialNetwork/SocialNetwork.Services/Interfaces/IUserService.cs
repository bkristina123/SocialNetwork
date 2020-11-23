using SocialNetwork.Data.Models;

namespace SocialNetwork.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        User GetSessionUser();
    }
}
