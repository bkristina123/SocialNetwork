using Microsoft.AspNetCore.Identity;
using SocialNetwork.ModelDTOs;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDTO registerDTO);
    }
}
