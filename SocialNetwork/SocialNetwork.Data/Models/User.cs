using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Data.Models
{
    public class User : IdentityUser<int>
    {

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        public byte[] ProfilePicture { get; set; }

        public List<Post> Posts { get; set; }
        
    }
}
