using QueueManagementSystem.Application.Feedbacks.QueryModels;
using QueueManagementSystem.Application.Feedbacks.QueryModels.Common;
using QueueManagementSystem.Application.Feedbacks.QueryModels.Insert;
using QueueManagementSystem.Application.Feedbacks.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
    public class FeedbackProfile : MappingProfile
    {
        public FeedbackProfile()
        {
            BuildMap<Feedback, FeedbackQueryModel>();
            BuildMap<Feedback, InsertFeedbackToBusinessQueryModel>();
            BuildMap<Feedback, InsertFeedbackToWorkerQueryModel>();
            BuildMap<Feedback, EditFeedbackQueryModel>();

            CreateMap<Feedback, FeedbackViewModel>()
                .ForPath(f => f.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForPath(f => f.UserLastName, opt => opt.MapFrom(src => src.User.LastName));
        }
    }
}