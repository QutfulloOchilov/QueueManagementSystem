using QueueManagementSystem.Application.Businesses.QueryModels.Common;
using QueueManagementSystem.Application.Businesses.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
	public class BusinessProfile : MappingProfile
	{
		public BusinessProfile()
		{
			BuildMap<Business, BusinessViewModel>();
			BuildMap<BusinessQueryModel, Business>();
		}
	}
}
