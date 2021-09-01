using QueueManagementSystem.Application.Jobs.QueryModels.Common;
using QueueManagementSystem.Application.Jobs.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
	public class JobProfile : MappingProfile
	{
		public JobProfile()
		{
			base.BuildMap<Job, JobViewModel>();
			base.BuildMap<JobQueryModel, Job>();
		}
	}
}
