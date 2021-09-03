using QueueManagementSystem.Application.Validators;

namespace QueueManagementSystem.Application.Jobs.QueryModels
{
	public class JobBaseQueryModelValidator<TJobQueryModel> : BaseAbstractValidation<TJobQueryModel> where TJobQueryModel : JobBaseQueryModel
	{

	}
}
