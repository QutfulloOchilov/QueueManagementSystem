using QueueManagementSystem.Application.DTOs;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
	public class ServiceDetailsProfile : MappingProfile
	{
		public ServiceDetailsProfile()
		{
			BuildMap<ServiceDetails, ServiceDetailsDTO>();
		}

		protected override void BuildMap<TSource, TDestination>()
		{
			CreateMap<TSource, TDestination>()
				.ForPath(dest => (dest as ServiceDetailsDTO).Name, opt => opt.MapFrom(sd => (sd as ServiceDetails).Service.Name));
			CreateMap<TDestination, TSource>();
			CreateMap<AddServiceDTO, TSource>();
		}
	}
}
