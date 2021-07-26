using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
	public class UserProfile : MappingProfile
	{
		public UserProfile()
		{
			BuildMap<Person, UserProfile>();
		}
	}
}
