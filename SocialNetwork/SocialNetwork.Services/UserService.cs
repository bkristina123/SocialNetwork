using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Common.Helpers;
using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.UserDTOs;
using SocialNetwork.Repositories;
using SocialNetwork.Services.Interfaces;
using System.Collections.Generic;
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

        public async Task<IdentityResult> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var sessionUser = GetSessionUser();
            var response = await _userManager.ChangePasswordAsync(sessionUser, changePasswordDTO.OldPassword, changePasswordDTO.NewPassword);
            return response;
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

        public IEnumerable<User> GetUsersByIds(IEnumerable<int> userIds)
        {
            return _userRepository.GetUsersByIds(userIds);
        }

        public async Task<IdentityResult> UpdateUser(EditUserDTO editUserDTO)
        {
            var updateModel = _userRepository.GetUserById(editUserDTO.Id);

            updateModel = await editUserDTO.UpdateToUser(updateModel);

            var response = await _userManager.UpdateAsync(updateModel);

            return response;
        }
    }
}
