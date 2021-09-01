using FluentValidation;

namespace QueueManagementSystem.Application.Jobs.QueryModels.Common
{
	public class JobQueryModelValidator<TQueryModel> : JobBaseQueryModelValidator<TQueryModel> where TQueryModel : JobQueryModel
	{
		public JobQueryModelValidator()
		{
			RuleFor(s => s.Name).MinimumLength(5);
		}
	}
}
