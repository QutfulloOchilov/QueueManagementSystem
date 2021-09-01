using QueueManagementSystem.Application.Workers.QueryModels;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
	public class ServiceDetailProfile : MappingProfile
	{
		public ServiceDetailProfile()
		{
			BuildMap<AddServiceQueryModel, ServiceDetail>();
		}

		protected override void BuildMap<TSource, TDestination>()
		{
			base.BuildMap<TSource, TDestination>();
			
			CreateMap<ServiceDetail, WorkerServiceViewModel>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Service.Name))
				.ForMember(dest => dest.ServiceDetailId, opt => opt.MapFrom(sd => sd.Id));
		}
	}
}
