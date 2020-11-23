using Microsoft.AspNetCore.Http;
using SocialNetwork.Data.Models;
using SocialNetwork.Repositories;
using SocialNetwork.Services.Interfaces;
using System.Security.Claims;

namespace SocialNetwork.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public User GetSessionUser()
        {
            var id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = GetUserById(int.Parse(id));

            return user;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
    }
}
