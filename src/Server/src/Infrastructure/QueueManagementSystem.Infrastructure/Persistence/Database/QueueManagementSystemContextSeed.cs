using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QueueManagementSystem.Domain.Comman;

namespace QueueManagementSystem.Infrastructure.Persistence.Database
{
    public static class QueueManagementSystemContextSeed
    {
        public static async Task Seed(UserManager<IdentityUser> userManager
            , RoleManager<IdentityRole> roleManager
            , QueueManagementSystemContext context)
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
                    UserName = "test",
                    Email = "test@example.com",
                };
                await userManager.CreateAsync(identityUser, "Test1234");
            }
        }
    }
}