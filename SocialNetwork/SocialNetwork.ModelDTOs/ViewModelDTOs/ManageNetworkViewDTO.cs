using SocialNetwork.Data.Models;
using System.Collections.Generic;

namespace SocialNetwork.ModelDTOs.ViewModelDTOs
{
    public class ManageNetworkViewDTO
    {
        public IEnumerable<FriendRequest> FriendRequests { get; set; }
        //prop for Friends List
    }
}
