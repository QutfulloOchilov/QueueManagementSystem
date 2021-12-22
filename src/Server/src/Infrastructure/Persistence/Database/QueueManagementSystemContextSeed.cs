using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QueueManagementSystem.Domain.Common;

namespace QueueManagementSystem.Infrastructure.Persistence.Database
{
    public static class QueueManagementSystemContextSeed
    {
        public static async Task Seed(UserManager<IdentityUser> userManager
            , RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                var applicationUserRole = new IdentityRole(UserRoles.ApplicationUser);
                var workerRole = new IdentityRole(UserRoles.Worker);
                await roleManager.CreateAsync(applicationUserRole);
                await roleManager.CreateAsync(workerRole);
            }

            if (!userManager.Users.Any())
            {
                var identityUser = new IdentityUser
                {
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com",
                };
                await userManager.CreateAsync(identityUser, "Test!.ksad923$51234!");
                await userManager.AddToRolesAsync(identityUser, new[] { UserRoles.Worker });
            }
            else
            {
                var identityUsers = userManager.Users.ToList();
            }
        }
    }
}