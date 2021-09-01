using QueueManagementSystem.Application.Validators;

namespace QueueManagementSystem.Application.Users.QueryModels
{
	public class UserBaseQueryModelValidator<TUserBaseQueryModel> : BaseAbstractValidation<TUserBaseQueryModel> where TUserBaseQueryModel : UserBaseQueryModel
	{

	}
}
