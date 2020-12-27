using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.PostDTOs;
using SocialNetwork.ModelDTOs.UserDTOs;
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

        public static ViewPostDTO ConvertToViewPostDTO(this Post post)
        {
            string photoContent = null;

            if(post.PhotoContent != null)
            {
                photoContent = Convert.ToBase64String(post.PhotoContent);
            }

            return new ViewPostDTO
            {
                Id = post.Id,
                UserId = post.UserId,
                UserFirstName = post.User.FirstName,
                UserLastName = post.User.LastName,
                PhotoContent = photoContent,
                TextContent = post.Content,
                DateCreated = post.DateCreated,
                UserProfilePhoto = Convert.ToBase64String(post.User.ProfilePicture)
            };
        }


        public static ProfileUserDTO ConvertToProfileUserDTO(this User user)
        {
            return new ProfileUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePhoto = Convert.ToBase64String(user.ProfilePicture),
            };
        }


        public static EditUserDTO ConvertToEditUserDTO(this User user)
        {
            return new EditUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

    }
}
