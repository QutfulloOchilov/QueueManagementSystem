using System.Threading.Tasks;

namespace QueueManagementSystem.Application.Repositories
{
	public interface IRepositoryWrapper
	{
		IUserRepository Users { get; }
		IBusinessRepository Businesses { get; }
		IServiceRepository Services { get; }
		IWorkerRepository Workers { get; }
		IFeedbackRepository Feedbacks { get; }
		IServiceDetailsRepository ServiceDetails { get; }
		int Save();
		Task<int> SaveAsync();
	}
}
