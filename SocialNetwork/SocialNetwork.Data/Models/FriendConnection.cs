using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Models
{
    public class FriendConnection
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("FirstUser")]
        public int FirstUserId { get; set; }
        public User FirstUser { get; set; }

        [Required]
        [ForeignKey("SecondUser")]
        public int SecondUserId { get; set; }
        public User SecondUser { get; set; }

    }
}
