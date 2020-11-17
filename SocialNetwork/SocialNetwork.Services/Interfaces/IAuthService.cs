using Microsoft.AspNetCore.Identity;
using SocialNetwork.ModelDTOs;
using SocialNetwork.ModelDTOs.ActionResponse;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDTO registerDTO);
        Task<SignInResponse> LoginUserAsync(LoginDTO loginDTO);
    }
}
