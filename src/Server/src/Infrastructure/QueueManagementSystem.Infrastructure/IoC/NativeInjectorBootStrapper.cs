using Microsoft.Extensions.DependencyInjection;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Mapper;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Infrastructure.Persistence;
using QueueManagementSystem.Infrastructure.Persistence.Database;
using QueueManagementSystem.Infrastructure.Persistence.Repositories;

namespace QueueManagementSystem.Infrastructure.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection service)
        {
            BuildeContext(service);
            BuildeServies(service);
            BuildeRepositories(service);
            BuildMappers(service);
            service.AddSingleton(service);

        }

        private static void BuildeContext(IServiceCollection service)
        {
            service.AddScoped<IContext, QueueManagementSystemContext>();
        }

        private static void BuildMappers(IServiceCollection builder)
        {
            builder.AddAutoMapper(typeof(MappingProfile));
        }

        private static void BuildeRepositories(IServiceCollection repository)
        {
            repository.AddTransient<IUnitOfWork, UnitOfWork>();
            repository.AddScoped<IPersonRepository, PersonRepository>();
        }

        private static void BuildeServies(IServiceCollection service)
        {

        }
    }
}
