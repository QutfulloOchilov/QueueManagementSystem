using QueueManagementSystem.Application.Validators;

namespace QueueManagementSystem.Application._Services.QueryModels
{
	public class ServiceBaseQueryModelValidator<TServiceQueryModel> : BaseAbstractValidation<TServiceQueryModel> where TServiceQueryModel : ServiceBaseQueryModel
	{

	}
}
