using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data.Models;

namespace SocialNetwork.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, UserRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }

        public DbSet<TextPost> TextPosts { get; set; }
    }
}
