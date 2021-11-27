using Microsoft.Extensions.DependencyInjection;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Businesses.Services;
using QueueManagementSystem.Application.Feedbacks.Services;
using QueueManagementSystem.Application.Jobs.Services;
using QueueManagementSystem.Application.Mapper;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Application.Users.Services;
using QueueManagementSystem.Application.Workers.Services;
using QueueManagementSystem.Application.WorkerSchedules.Services;
using QueueManagementSystem.Infrastructure.Persistence;
using QueueManagementSystem.Infrastructure.Persistence.Database;
using QueueManagementSystem.Infrastructure.Persistence.Repositories;
using QueueManagementSystem.Services;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using QueueManagementSystem.Infrastructure.Identity;

namespace QueueManagementSystem.Infrastructure.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            BuildContext(services);
            BuildServices(services);
            BuildRepositories(services);
            BuildMappers(services);
            BuildIdentity(services);
            services.AddSingleton(services);
        }

        private static void BuildIdentity(IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<QueueManagementSystemContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<IdentityUser, QueueManagementSystemContext>();

            services.Configure<JwtBearerOptions>(IdentityServerJwtConstants.IdentityServerJwtBearerScheme,
                options =>
                {
                    options.Audience = "queueClients";
                    options.Authority = "queueApi";
                    options.TokenValidationParameters.RequireExpirationTime = true;
                    options.TokenValidationParameters.ValidateAudience = true;
                    options.TokenValidationParameters.ValidateIssuerSigningKey = true;
                    options.TokenValidationParameters.IssuerSigningKey = SigningKeyProvider.GetSecurityKey();
                });

            services.AddAuthentication()
                .AddIdentityServerJwt();
            services.AddAuthorization();
        }

        private static void BuildContext(IServiceCollection service)
        {
            service.AddDbContext<IContext, QueueManagementSystemContext>();
        }

        private static void BuildMappers(IServiceCollection builder)
        {
            builder.AddAutoMapper(typeof(MappingProfile));
        }

        private static void BuildRepositories(IServiceCollection repository)
        {
            repository.AddTransient<IUnitOfWork, UnitOfWork>();
            repository.AddScoped<IWorkerRepository, WorkerRepository>();
            repository.AddScoped<IBusinessRepository, BusinessRepository>();
            repository.AddScoped<IWorkerScheduleRepository, WorkerScheduleRepository>();
            repository.AddScoped<IJobRepository, JobRepository>();
            repository.AddScoped<IUserRepository, UserRepository>();
            repository.AddScoped<IJobDetailRepository, JobDetailRepository>();
            repository.AddScoped<IFeedbackRepository, FeedbackRepository>();
        }

        private static void BuildServices(IServiceCollection service)
        {
            service.AddScoped<IWorkerService, WorkerService>();
            service.AddScoped<IBusinessService, BusinessService>();
            service.AddScoped<IWorkerScheduleService, WorkerScheduleService>();
            service.AddScoped<IJobService, JobService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IFeedbackService, FeedbackService>();
        }
    }
}