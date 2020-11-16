using Microsoft.AspNetCore.Identity;
using SocialNetwork.Common.Helpers;
using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs;
using SocialNetwork.Services.Interfaces;
using System.Threading.Tasks;

namespace SocialNetwork.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;

        public AuthService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(RegisterDTO registerDTO)
        {

            var user = registerDTO.ConvertToUserEntity();

            return await _userManager.CreateAsync(user, registerDTO.Password);
        }
    }
}
