using Microsoft.AspNetCore.Identity;
using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.UserDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        User GetSessionUser();
        Task<IdentityResult> UpdateUser(EditUserDTO editUserDTO);
        Task<IdentityResult> ChangePassword(ChangePasswordDTO changePasswordDTO);
        IEnumerable<User> GetUsersByIds(IEnumerable<int> userIds);
    }
}
