using QueueManagementSystem.Application.DTOs;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
	public class WorkerProfile : MappingProfile
	{
		public WorkerProfile()
		{
			BuildMap<Worker, WorkerDTO>();
		}

		protected override void BuildMap<TSource, TDestination>()
		{
			CreateMap<TSource, TDestination>();
			CreateMap<TDestination, TSource>();
			CreateMap<TSource, WorkerServicesDTO>()
				.ForMember(dest => dest.WorkerId, src => src.MapFrom(w => (w as Worker).Id));
		}
	}
}
