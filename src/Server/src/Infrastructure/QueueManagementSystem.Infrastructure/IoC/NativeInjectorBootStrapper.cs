using Microsoft.Extensions.DependencyInjection;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Businesses.Services;
using QueueManagementSystem.Application.Categories.Services;
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
			repository.AddScoped<IWorkerRepository, WorkerRepository>();
			repository.AddScoped<IBusinessRepository, BusinessRepository>();
			repository.AddScoped<IWorkerScheduleRepository, WorkerScheduleRepository>();
			repository.AddScoped<IJobRepository, JobRepository>();
			repository.AddScoped<IUserRepository, UserRepository>();
			repository.AddScoped<IJobDetailRepository, JobDetailRepository>();
			repository.AddScoped<IFeedbackRepository, FeedbackRepository>();
			repository.AddScoped<ICategoryRepository, CategoryRepository>();
		}

		private static void BuildServices(IServiceCollection service)
		{
			service.AddScoped<IWorkerService, WorkerService>();
			service.AddScoped<IBusinessService, BusinessService>();
			service.AddScoped<IWorkerScheduleService, WorkerScheduleService>();
			service.AddScoped<IJobService, JobService>();
			service.AddScoped<IUserService, UserService>();
			service.AddScoped<IFeedbackService, FeedbackService>();
			service.AddScoped<ICategoryService, CategoryService>();
		}
	}
}
