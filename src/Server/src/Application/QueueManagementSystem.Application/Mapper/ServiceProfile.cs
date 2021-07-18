using QueueManagementSystem.Application.DTOs;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
	public class ServiceProfile : MappingProfile
	{
		public ServiceProfile()
		{
			BuildMap<Service, ServiceDTO>();
		}
	}
}
