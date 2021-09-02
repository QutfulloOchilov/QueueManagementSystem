using QueueManagementSystem.Application.Feedbacks.QueryModels;
using QueueManagementSystem.Application.Feedbacks.ViewModels;
using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Feedbacks.Services
{
	public interface IFeedbackService : IService<Feedback, FeedbackViewModel, FeedbackBaseQueryModel>
	{

	}
}
