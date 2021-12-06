using QueueManagementSystem.Application.Workers.QueryModels.Common;

namespace QueueManagementSystem.Application.Workers.QueryModels.Insert
{
    public class InsertWorkerQueryModel : WorkerQueryModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}