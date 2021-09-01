using FluentValidation;

namespace QueueManagementSystem.Application._Services.QueryModels.Common
{
	public class ServiceQueryModelValidator<TQueryModel> : ServiceBaseQueryModelValidator<TQueryModel> where TQueryModel : ServiceQueryModel
	{
		public ServiceQueryModelValidator()
		{
			RuleFor(s => s.Name).MinimumLength(5);
		}
	}
}
