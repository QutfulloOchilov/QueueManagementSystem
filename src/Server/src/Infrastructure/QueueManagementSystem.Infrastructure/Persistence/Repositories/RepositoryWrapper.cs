using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using System.Threading.Tasks;

namespace QueueManagementSystem.Infrastructure.Persistence.Repositories
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private IUserRepository userRepo;
		private IBusinessRepository businessRepo;
		private IServiceRepository serviceRepo;
		private IWorkerRepository workerRepo;
		private IFeedbackRepository feedbackRepo;
		private IServiceDetailRepository serviceDetailsRepo;
		private IContext db;

		public RepositoryWrapper(IContext _db)
		{
			db = _db;
		}

		public IUserRepository Users
		{
			get
			{
				if (userRepo == null)
					userRepo = new UserRepository(db);
				return userRepo;
			}
		}

		public IBusinessRepository Businesses
		{
			get
			{
				if (businessRepo == null)
					businessRepo = new BusinessRepository(db);
				return businessRepo;
			}
		}

		public IServiceRepository Services
		{
			get
			{
				if (serviceRepo == null)
					serviceRepo = new ServiceRepository(db);
				return serviceRepo;
			}
		}

		public IWorkerRepository Workers
		{ 
			get
			{
				if (workerRepo == null)
					workerRepo = new WorkerRepository(db);
				return workerRepo;
			}
		}

		public IFeedbackRepository Feedbacks
		{
			get
			{
				if (feedbackRepo == null)
					feedbackRepo = new FeedbackRepository(db);
				return feedbackRepo;
			}
		}

		public IServiceDetailRepository ServiceDetails
		{
			get
			{
				if (serviceDetailsRepo == null)
					serviceDetailsRepo = new ServiceDetailRepository(db);
				return serviceDetailsRepo;
			}
		}

		public int Save()
		{
			return db.SaveChanges();
		}

		public async Task<int> SaveAsync()
		{
			return await db.SaveChangesAsync();
		}
	}
}
