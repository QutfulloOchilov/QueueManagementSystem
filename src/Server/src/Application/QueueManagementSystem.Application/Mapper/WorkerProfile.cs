using QueueManagementSystem.Application.Workers.QueryModels.Common;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
	public class WorkerProfile : MappingProfile
	{
		public WorkerProfile()
		{
			BuildMap<Worker, WorkerViewModel>();
		}

		protected override void BuildMap<TSource, TDestination>()
		{
			base.BuildMap<TSource, TDestination>();
			CreateMap<WorkerQueryModel, TSource>();
		}
	}
}
