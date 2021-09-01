using QueueManagementSystem.Application._Services.QueryModels.Common;
using QueueManagementSystem.Application._Services.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
	public class ServiceProfile : MappingProfile
	{
		public ServiceProfile()
		{
			BuildMap<Service, ServiceViewModel>();
			BuildMap<ServiceQueryModel, Service>();
		}
	}
}
