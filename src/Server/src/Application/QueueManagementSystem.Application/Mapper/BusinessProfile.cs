using QueueManagementSystem.Application.DTOs;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
	public class BusinessProfile : MappingProfile
	{
		public BusinessProfile()
		{
			BuildMap<Business, BusinessDTO>();
		}
	}
}
