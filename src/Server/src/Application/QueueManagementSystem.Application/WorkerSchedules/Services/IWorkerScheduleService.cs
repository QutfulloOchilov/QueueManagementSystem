using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Application.WorkerSchedules.QueryModels;
using QueueManagementSystem.Application.WorkerSchedules.ViewModels;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueueManagementSystem.Application.WorkerSchedules.Services
{
	public interface IWorkerScheduleService : IService<WorkerSchedule, WorkerScheduleViewModel, WorkerScheduleBaseQueryModel>
	{
		Task<IEnumerable<WorkerScheduleViewModel>> GetWorkerSchedule(Guid workerId);
	}
}
