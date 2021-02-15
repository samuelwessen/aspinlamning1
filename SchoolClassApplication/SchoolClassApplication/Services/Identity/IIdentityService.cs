using Microsoft.AspNetCore.Identity;
using SchoolClassApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolClassApplication.Services.Identity
{
    public interface IIdentityService
    {
        Task CreateRootAccountAsync();
        Task<IdentityResult> CreateNewUserAsync(ApplicationUser user, string password);
        Task AddUserToRoleAsync(ApplicationUser user, string roleName);
        IEnumerable<ApplicationUser> GetAllUsers();
        IEnumerable<IdentityRole> GetAllRoles();
    }
}
