using FluentValidation;

namespace QueueManagementSystem.Application.Businesses.QueryModels.Common
{
    public class BusinessQueryModelValidator<TQueryModel> : BusinessBaseQueryModelValidator<TQueryModel>
        where TQueryModel : BusinessQueryModel
    {
        public BusinessQueryModelValidator()
        {
            RuleFor(b => b.Name).NotEmpty().NotNull().MinimumLength(4);
            RuleFor(b => b.Address).NotEmpty().NotNull();
        }
    }
}