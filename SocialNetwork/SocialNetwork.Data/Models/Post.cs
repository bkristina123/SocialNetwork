using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Data.Models
{
    public class Post 
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public byte[] PhotoContent { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
