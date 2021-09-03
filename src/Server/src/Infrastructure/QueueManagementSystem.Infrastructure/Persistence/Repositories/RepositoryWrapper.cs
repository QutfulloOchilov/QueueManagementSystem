using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using System.Threading.Tasks;

namespace QueueManagementSystem.Infrastructure.Persistence.Repositories
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private IUserRepository userRepo;
		private IBusinessRepository businessRepo;
		private IJobRepository serviceRepo;
		private IWorkerRepository workerRepo;
		private IFeedbackRepository feedbackRepo;
		private IJobDetailRepository jobDetailsRepo;
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

		public IJobRepository Services
		{
			get
			{
				if (serviceRepo == null)
					serviceRepo = new JobRepository(db);
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

		public IJobDetailRepository JobDetails
		{
			get
			{
				if (jobDetailsRepo == null)
					jobDetailsRepo = new JobDetailRepository(db);
				return jobDetailsRepo;
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
