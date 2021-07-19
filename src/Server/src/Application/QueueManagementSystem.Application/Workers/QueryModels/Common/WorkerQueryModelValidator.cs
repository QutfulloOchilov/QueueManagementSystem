using FluentValidation;

namespace QueueManagementSystem.Application.Workers.QueryModels.Common
{
    public class WorkerQueryModelValidator<TQueryModel> : WorkerBaseQueryModelValidator<TQueryModel> where TQueryModel : WorkerQueryModel
    {
        public WorkerQueryModelValidator() : base()
        {
            RuleFor(s => s.LastName).NotEmpty().MinimumLength(4);
            RuleFor(s => s.FirstName).NotEmpty().MinimumLength(4);
        }
    }
}
