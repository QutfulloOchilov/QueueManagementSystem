using FluentValidation;
using QueueManagementSystem.Application.QueryModels;

namespace QueueManagementSystem.Application.Validators
{
    public abstract class BaseAbstractValidation<TQueryModel> : AbstractValidator<TQueryModel>, IBaseQuerymodelValidator where TQueryModel : BaseQueryModel { }
}
