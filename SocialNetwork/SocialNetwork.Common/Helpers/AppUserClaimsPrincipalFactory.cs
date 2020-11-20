using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SocialNetwork.Data.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialNetwork.Common.Helpers
{
    public class AppUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, UserRole>
    {
        public AppUserClaimsPrincipalFactory(UserManager<User> userManager,
            RoleManager<UserRole> roleManager, IOptions<IdentityOptions> options)
            :base(userManager, roleManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FirstName", user.FirstName));
            identity.AddClaim(new Claim("LastName", user.LastName));

            return identity;
        }
    }
}
