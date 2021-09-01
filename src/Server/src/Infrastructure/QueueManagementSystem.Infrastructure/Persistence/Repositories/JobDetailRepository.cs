using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Infrastructure.Persistence.Repositories
{
	public class JobDetailRepository : BaseRepository<JobDetail>, IJobDetailRepository
	{
		public JobDetailRepository(IContext _db)
			: base(_db)
		{

		}
	}
}
