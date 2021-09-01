using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Application.Workers.QueryModels;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueueManagementSystem.Application.Workers.Services
{
	public interface IWorkerService : IService<Worker, WorkerViewModel, WorkerBaseQueryModel>
	{
		Task AddService(AddServiceQueryModel model);
		Task<IEnumerable<WorkerServiceViewModel>> GetServices(Guid workerId);
		Task UpdateService(UpdateServiceQueryModel model);
		Task DeleteService(DeleteServiceQueryModel model);
		Task<IEnumerable<WorkerReservationViewModel>> GetReservations(Guid workerId);
	}
}
