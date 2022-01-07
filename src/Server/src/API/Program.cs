using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QueueManagementSystem.Infrastructure.Persistence.Database;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Reflection;

namespace QueueManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SetupLogging();

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

        static void SetupLogging()
        {
            // Get the environment which the application is running on
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Get the configuration 
            var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

            // Create Logger
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails() // Adds details exception
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(ConfigureELS(configuration, env))
                .CreateLogger();
        }

        static ElasticsearchSinkOptions ConfigureELS(IConfigurationRoot configuration, string env)
        {
            return new ElasticsearchSinkOptions(new Uri(configuration["ELKConfiguration:Url"]))
            {
                AutoRegisterTemplate = true,
                IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower()}-{env.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
            };
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}