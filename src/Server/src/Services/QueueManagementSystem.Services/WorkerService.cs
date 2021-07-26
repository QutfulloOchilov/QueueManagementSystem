using AutoMapper;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Application.Workers.QueryModels;
using QueueManagementSystem.Application.Workers.Services;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Services
{
    public class WorkerService : BaseService<Worker, WorkerViewModel, WorkerBaseQueryModel>, IWorkerService
    {
        public WorkerService(IUnitOfWork unitOfWork, IWorkerRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper)
        {

        }
    }
}
