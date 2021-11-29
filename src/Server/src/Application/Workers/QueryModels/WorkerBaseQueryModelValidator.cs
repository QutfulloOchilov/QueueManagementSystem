using QueueManagementSystem.Application.Validators;

namespace QueueManagementSystem.Application.Workers.QueryModels
{
    public class WorkerBaseQueryModelValidator<TWorkerBaseQueryModel> : BaseAbstractValidation<TWorkerBaseQueryModel>
        where TWorkerBaseQueryModel : WorkerBaseQueryModel
    {
    }
}