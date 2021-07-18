using Microsoft.Extensions.DependencyInjection;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Mapper;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Infrastructure.Persistence;
using QueueManagementSystem.Infrastructure.Persistence.Database;
using QueueManagementSystem.Infrastructure.Persistence.Repositories;

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
			services.AddSingleton(services);
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
			repository.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
		}

		private static void BuildServices(IServiceCollection service)
		{

		}
	}
}
