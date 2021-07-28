using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Infrastructure.Persistence.Repositories
{
	public class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
	{
		public FeedbackRepository(IContext _db)
			: base(_db)
		{

		}
	}
}
