using System.Threading.Tasks;

namespace QueueManagementSystem.Application.Repositories
{
	public interface IRepositoryWrapper
	{
		IUserRepository Users { get; }
		IBusinessRepository Businesses { get; }
		IJobRepository Services { get; }
		IWorkerRepository Workers { get; }
		IFeedbackRepository Feedbacks { get; }
		IJobDetailRepository JobDetails { get; }
		int Save();
		Task<int> SaveAsync();
	}
}
