using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs;

namespace SocialNetwork.Common.Helpers
{
    public static class Convertor
    {
        public static User ConvertToUserEntity(this RegisterDTO registerDTO)
        {
            return new User()
            {
                Id = registerDTO.Id,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                UserName = registerDTO.Email
            };
        }
    }
}
