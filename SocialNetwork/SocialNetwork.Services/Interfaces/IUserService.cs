using Microsoft.AspNetCore.Identity;
using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.UserDTOs;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        User GetSessionUser();
        Task<IdentityResult> UpdateUser(EditUserDTO editUserDTO);
    }
}
