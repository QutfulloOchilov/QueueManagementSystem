using QueueManagementSystem.Application.Validators;

namespace QueueManagementSystem.Application.WorkerSchedules.QueryModels
{
	public class WorkerScheduleBaseQueryModelValidator<TBusinessBaseQueryModel> : BaseAbstractValidation<TBusinessBaseQueryModel> where TBusinessBaseQueryModel : WorkerScheduleBaseQueryModel
	{

	}
}
