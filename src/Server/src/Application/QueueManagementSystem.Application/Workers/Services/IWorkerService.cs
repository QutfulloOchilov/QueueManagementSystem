using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Application.Workers.QueryModels;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Workers.Services
{
    public interface IWorkerService : IService<Worker, WorkerViewModel, WorkerBaseQueryModel>
    {

    }
}
