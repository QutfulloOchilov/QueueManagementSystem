using AutoMapper;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Jobs.QueryModels;
using QueueManagementSystem.Application.Jobs.Services;
using QueueManagementSystem.Application.Jobs.ViewModels;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Services
{
    public class JobService : BaseService<Job, JobViewModel, JobBaseQueryModel>, IJobService
    {
        public JobService(IUnitOfWork unitOfWork, IJobRepository repository, IMapper mapper)
            : base(unitOfWork, repository, mapper)
        {
        }
    }
}