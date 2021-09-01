using AutoMapper;
using QueueManagementSystem.Application._Services.QueryModels;
using QueueManagementSystem.Application._Services.Services;
using QueueManagementSystem.Application._Services.ViewModels;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Services
{
	public class ServiceService : BaseService<Service, ServiceViewModel, ServiceBaseQueryModel>, IServiceService
	{
		public ServiceService(IUnitOfWork unitOfWork, IServiceRepository repository, IMapper mapper)
			: base(unitOfWork, repository, mapper)
		{

		}
	}
}
