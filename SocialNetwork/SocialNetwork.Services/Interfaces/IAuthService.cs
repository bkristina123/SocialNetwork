using Microsoft.AspNetCore.Identity;
using SocialNetwork.ModelDTOs.ActionResponse;
using SocialNetwork.UserDTOs;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDTO registerDTO);
        Task<SignInResponse> LoginUserAsync(LoginDTO loginDTO);
        Task LogoutAsync();
    }
}
