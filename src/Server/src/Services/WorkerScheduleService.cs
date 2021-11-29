using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Application.WorkerSchedules.QueryModels;
using QueueManagementSystem.Application.WorkerSchedules.Services;
using QueueManagementSystem.Application.WorkerSchedules.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Services
{
    public class WorkerScheduleService :
        BaseService<WorkerSchedule, WorkerScheduleViewModel, WorkerScheduleBaseQueryModel>, IWorkerScheduleService
    {
        public WorkerScheduleService(IUnitOfWork unitOfWork, IWorkerScheduleRepository repository, IMapper mapper)
            : base(unitOfWork, repository, mapper)
        {
        }

        public async Task<IEnumerable<WorkerScheduleViewModel>> GetWorkerSchedule(Guid workerId)
        {
            var schedules = await Repository.GetAllAsync(ws => ws.WorkerId == workerId);
            return Mapper.Map<IEnumerable<WorkerScheduleViewModel>>(schedules);
        }
    }
}