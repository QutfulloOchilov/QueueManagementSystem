using AutoMapper;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Businesses.QueryModels;
using QueueManagementSystem.Application.Businesses.Services;
using QueueManagementSystem.Application.Businesses.ViewModels;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Services
{
	public class BusinessService : BaseService<Business, BusinessViewModel, BusinessBaseQueryModel>, IBusinessService
	{
		public BusinessService(IUnitOfWork unitOfWork, IBusinessRepository repository, IMapper mapper)
			: base(unitOfWork, repository, mapper)
		{

		}
	}
}
