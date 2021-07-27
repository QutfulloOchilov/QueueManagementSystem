using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Infrastructure.Persistence.Repositories
{
	public class ServiceDetailRepository : BaseRepository<ServiceDetail>, IServiceDetailRepository
	{
		public ServiceDetailRepository(IContext _db)
			: base(_db)
		{

		}
	}
}
