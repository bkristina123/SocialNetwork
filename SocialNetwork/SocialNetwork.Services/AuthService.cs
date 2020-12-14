using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SocialNetwork.Common.Helpers;
using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.ActionResponse;
using SocialNetwork.Services.Interfaces;
using SocialNetwork.UserDTOs;
using System.Threading.Tasks;

namespace SocialNetwork.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> CreateUserAsync(RegisterDTO registerDTO)
        {

            var user = await registerDTO.ConvertToUserEntity();

            return await _userManager.CreateAsync(user, registerDTO.Password);
        }

        public async Task<SignInResponse> LoginUserAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            var response = new SignInResponse();

            if(user is null)
            {
                response.ErrorMessage = _configuration["ErrorMessages:UserExistError"];
                return response;
            }

            PasswordVerificationResult passResult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDTO.Password);

            if (passResult.Equals(PasswordVerificationResult.Failed))
            {
                response.ErrorMessage = _configuration["ErrorMessages:InvalidPassError"];
                return response;
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user.Email, loginDTO.Password, false, false);

            if(!signInResult.Succeeded)
            {
                response.ErrorMessage = _configuration["ErrorMessages:FailedLoginError"];
                return response;
            }

            response.IsSuccesful = true;
            return response;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
