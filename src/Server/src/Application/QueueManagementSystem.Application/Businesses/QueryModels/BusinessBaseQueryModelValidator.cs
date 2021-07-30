using QueueManagementSystem.Application.Validators;

namespace QueueManagementSystem.Application.Businesses.QueryModels
{
	public class BusinessBaseQueryModelValidator<TBusinessBaseQueryModel> : BaseAbstractValidation<TBusinessBaseQueryModel> where TBusinessBaseQueryModel : BusinessBaseQueryModel
	{

	}
}
