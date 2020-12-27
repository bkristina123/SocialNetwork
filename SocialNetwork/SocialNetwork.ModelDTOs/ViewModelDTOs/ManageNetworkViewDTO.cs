using SocialNetwork.Data.Models;
using SocialNetwork.ModelDTOs.UserDTOs;
using System.Collections.Generic;

namespace SocialNetwork.ModelDTOs.ViewModelDTOs
{
    public class ManageNetworkViewDTO
    {
        public IEnumerable<FriendRequest> FriendRequests { get; set; }
        public IEnumerable<ProfileUserDTO> UserFriends { get; set; }
    }
}
