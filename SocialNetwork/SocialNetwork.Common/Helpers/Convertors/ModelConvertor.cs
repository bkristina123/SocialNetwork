using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.UserDTOs;
using SocialNetwork.UserDTOs;
using System.Threading.Tasks;

namespace SocialNetwork.Common.Helpers
{
    public static class ModelConvertor
    {
        public static async Task<User> ConvertToUserEntity(this RegisterDTO registerDTO)
        {
            return new User()
            {
                Id = registerDTO.Id,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                UserName = registerDTO.Email,
                ProfilePicture = await registerDTO.ProfilePicture.ConvertImageToByte(),
            };
        }


        public static async Task<User> UpdateToUser(this EditUserDTO editUserDTO, User user)
        {

            user.FirstName = editUserDTO.FirstName;
            user.LastName = editUserDTO.LastName;

            if(editUserDTO.ProfilePhoto != null)
            {
                user.ProfilePicture = await editUserDTO.ProfilePhoto.ConvertImageToByte();
            }


            return user;
        }

    }
}
