using FluentValidation;

namespace QueueManagementSystem.Application.Feedbacks.QueryModels.Common
{
    public class FeedbackQueryModelValidator<TQueryModel> : FeedbackBaseQueryModelValidator<TQueryModel>
        where TQueryModel : FeedbackQueryModel
    {
        public FeedbackQueryModelValidator()
        {
            RuleFor(s => s.Star).LessThan(6).GreaterThan(0);
            RuleFor(s => s.UserId).NotEmpty();
        }
    }
}