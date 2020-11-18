using Microsoft.AspNetCore.Identity;
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

        public AuthService(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                response.ErrorMessage = $"User with e-mail {loginDTO.Email} doesn't exist";
                return response;
            }

            PasswordVerificationResult passResult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDTO.Password);

            if (passResult.Equals(PasswordVerificationResult.Failed))
            {
                response.ErrorMessage = "Invalid password";
                return response;
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user.Email, loginDTO.Password, false, false);

            if(!signInResult.Succeeded)
            {
                response.ErrorMessage = "Failed Login. Try Again!";
                return response;
            }

            response.IsSuccesful = true;
            return response;
        }
    }
}
