using System;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int PostId { get; set; }
        public Post Post { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
