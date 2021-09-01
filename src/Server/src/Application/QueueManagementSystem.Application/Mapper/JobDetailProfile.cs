using QueueManagementSystem.Application.Workers.QueryModels;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
	public class JobDetailProfile : MappingProfile
	{
		public JobDetailProfile()
		{
			BuildMap<AddJobQueryModel, JobDetail>();
		}

		protected override void BuildMap<TSource, TDestination>()
		{
			base.BuildMap<TSource, TDestination>();
			
			CreateMap<JobDetail, WorkerJobViewModel>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Job.Name))
				.ForMember(dest => dest.JobDetailId, opt => opt.MapFrom(sd => sd.Id));
		}
	}
}
