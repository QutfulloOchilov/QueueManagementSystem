using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Infrastructure.Persistence.Repositories
{
	public class ServiceDetailsRepository : BaseRepository<ServiceDetails>, IServiceDetailsRepository
	{
		public ServiceDetailsRepository(IContext _db)
			: base(_db)
		{

		}
	}
}
