using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Models
{
    public class FriendRequest
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("FromUser")]
        public int FromUserId { get; set; }
        public User FromUser { get; set; }

        [Required]
        [ForeignKey("ToUser")]
        public int ToUserId { get; set; }
        public User ToUser { get; set; }
    }
}
