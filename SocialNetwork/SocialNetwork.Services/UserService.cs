using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Common.Helpers;
using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.UserDTOs;
using SocialNetwork.Repositories;
using SocialNetwork.Services.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialNetwork.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository userRepository,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _userManager = userManager;
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

        public async Task<IdentityResult> UpdateUser(EditUserDTO editUserDTO)
        {
            var targetUser = _userRepository.GetUserById(editUserDTO.Id);

            targetUser = await editUserDTO.UpdateToUser(targetUser);

            var response = await _userManager.UpdateAsync(targetUser);

            return response;
        }
    }
}
