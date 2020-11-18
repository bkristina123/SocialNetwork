using SocialNetwork.Data.Models;
using SocialNetwork.Repositories;
using SocialNetwork.Services.Interfaces;

namespace SocialNetwork.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
    }
}
