using QueueManagementSystem.Application.Jobs.QueryModels;
using QueueManagementSystem.Application.Jobs.ViewModels;
using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Jobs.Services
{
	public interface IJobService : IService<Job, JobViewModel, JobBaseQueryModel>
	{
	}
}
