using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolClassApplication.Data
{
    public class ApplicationUserClaims : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaims(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var roles = await UserManager.GetRolesAsync(user);


            var _identity = await base.GenerateClaimsAsync(user);

            _identity.AddClaim(new Claim("FirstName", user.FirstName ?? ""));
            _identity.AddClaim(new Claim("LastName", user.LastName ?? ""));
            _identity.AddClaim(new Claim("DisplayName", user.GetDisplayName ?? ""));
            _identity.AddClaim(new Claim(ClaimTypes.Role, roles.FirstOrDefault()));

            return _identity;
        }
    }
}
