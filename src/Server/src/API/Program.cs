using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QueueManagementSystem.Infrastructure.Persistence.Database;

namespace QueueManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;
                var queueManagementSystemContext = serviceProvider.GetRequiredService<QueueManagementSystemContext>();
                queueManagementSystemContext.Database.EnsureCreated();

                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                QueueManagementSystemContextSeed.Seed(userManager, roleManager).Wait();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}