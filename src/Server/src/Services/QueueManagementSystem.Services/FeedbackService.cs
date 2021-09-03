using AutoMapper;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Feedbacks.QueryModels;
using QueueManagementSystem.Application.Feedbacks.QueryModels.Insert;
using QueueManagementSystem.Application.Feedbacks.Services;
using QueueManagementSystem.Application.Feedbacks.ViewModels;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;
using System.Threading.Tasks;

namespace QueueManagementSystem.Services
{
	public class FeedbackService : BaseService<Feedback, FeedbackViewModel, FeedbackBaseQueryModel>, IFeedbackService
	{
		private readonly IUserRepository userRepository;

		public FeedbackService(IUnitOfWork unitOfWork, IFeedbackRepository repository, IUserRepository _userRepository, IMapper mapper)
			: base(unitOfWork, repository, mapper)
		{
			userRepository = _userRepository;
		}

		public async override Task<FeedbackViewModel> Create(FeedbackBaseQueryModel newEntity)
		{
			var entity = await CreateEntity(newEntity);

			if (newEntity is InsertFeedbackToWorkerQueryModel)
				entity.User = await userRepository.GetByIdAsync((newEntity as InsertFeedbackToWorkerQueryModel).UserId);
			else if (newEntity is InsertFeedbackToBusinessQueryModel)
				entity.User = await userRepository.GetByIdAsync((newEntity as InsertFeedbackToBusinessQueryModel).UserId);

			await UnitOfWork.SaveChangesAsync();

			return Mapper.Map<Feedback, FeedbackViewModel>(entity);
		}
	}
}
