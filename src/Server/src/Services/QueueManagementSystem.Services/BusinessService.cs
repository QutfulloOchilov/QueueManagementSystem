using AutoMapper;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Businesses.QueryModels;
using QueueManagementSystem.Application.Businesses.Services;
using QueueManagementSystem.Application.Businesses.ViewModels;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueueManagementSystem.Services
{
	public class BusinessService : BaseService<Business, BusinessViewModel, BusinessBaseQueryModel>, IBusinessService
	{
		public BusinessService(IUnitOfWork unitOfWork, IBusinessRepository repository, IMapper mapper)
			: base(unitOfWork, repository, mapper)
		{

		}

		public async Task<IEnumerable<WorkerViewModel>> GetWorkers(Guid businessId)
		{
			var business = await Repository.GetFirstOrDefaultAsync(predicate: b => b.Id == businessId, disableTracking: false);
			return Mapper.Map<IEnumerable<WorkerViewModel>>(business.Workers);
		}
	}
}
