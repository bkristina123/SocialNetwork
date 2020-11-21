using System;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Data.Models
{
    public class TextPost
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
