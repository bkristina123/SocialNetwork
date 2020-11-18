using SocialNetwork.Data.Models;
using SocialNetwork.UserDTOs;
using System;

namespace SocialNetwork.Common.Helpers
{
    public static class DtoConvertor
    {
        public static HomepageUserDTO ConvertToHomepageUserDTO(this User user)
        {
            return new HomepageUserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePhoto = Convert.ToBase64String(user.ProfilePicture),
            };
        }
    }
}
