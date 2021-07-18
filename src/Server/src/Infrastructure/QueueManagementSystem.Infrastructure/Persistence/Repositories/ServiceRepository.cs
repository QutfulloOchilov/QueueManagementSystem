using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Infrastructure.Persistence.Repositories
{
	public class ServiceRepository : BaseRepository<Service>, IServiceRepository
	{
		public ServiceRepository(IContext _db)
			: base(_db)
		{

		}
	}
}
