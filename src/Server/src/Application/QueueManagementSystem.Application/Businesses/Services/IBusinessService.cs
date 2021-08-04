using QueueManagementSystem.Application.Businesses.QueryModels;
using QueueManagementSystem.Application.Businesses.ViewModels;
using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueueManagementSystem.Application.Businesses.Services
{
	public interface IBusinessService : IService<Business, BusinessViewModel, BusinessBaseQueryModel>
	{
		Task<IEnumerable<WorkerViewModel>> GetWorkers(Guid businessId);
	}
}
