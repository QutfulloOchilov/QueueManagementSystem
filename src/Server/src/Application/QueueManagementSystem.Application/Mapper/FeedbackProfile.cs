using QueueManagementSystem.Application.DTOs;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
	public class FeedbackProfile : MappingProfile
	{
		public FeedbackProfile()
		{
			BuildMap<Feedback, FeedbackDTO>();
		}

		protected override void BuildMap<TSource, TDestination>()
		{
			CreateMap<TSource, TDestination>();
			CreateMap<TDestination, TSource>();
			CreateMap<Worker, WorkerDTO>();
			CreateMap<Business, BusinessDTO>();
			CreateMap<User, UserDTO>();
		}
	}
}
