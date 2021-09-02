using QueueManagementSystem.Application.Feedbacks.QueryModels.Common;
using QueueManagementSystem.Application.Feedbacks.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
	public class FeedbackProfile : MappingProfile
	{
		public FeedbackProfile()
		{
			BuildMap<Feedback, FeedbackViewModel>();
			BuildMap<Feedback, FeedbackQueryModel>();
		}
	}
}
