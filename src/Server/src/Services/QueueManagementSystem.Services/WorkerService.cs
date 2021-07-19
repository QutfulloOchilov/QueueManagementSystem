﻿using AutoMapper;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Workers.QueryModels;
using QueueManagementSystem.Application.Workers.Services;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Services
{
    public class WorkerService : BaseService<Worker, WorkerViewModel, WorkerBaseQueryModel>, IWorkerService
    {
        public WorkerService(IUnitOfWork unitOfWork, IRepository<Worker> repository, IMapper mapper) : base(unitOfWork, repository, mapper)
        {
        }
    }
}
