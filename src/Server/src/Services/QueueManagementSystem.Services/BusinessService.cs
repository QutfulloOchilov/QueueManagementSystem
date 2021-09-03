using AutoMapper;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Businesses.QueryModels;
using QueueManagementSystem.Application.Businesses.Services;
using QueueManagementSystem.Application.Businesses.ViewModels;
using QueueManagementSystem.Application.Feedbacks.QueryModels;
using QueueManagementSystem.Application.Feedbacks.QueryModels.Insert;
using QueueManagementSystem.Application.Feedbacks.Services;
using QueueManagementSystem.Application.Feedbacks.ViewModels;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueueManagementSystem.Services
{
	public class BusinessService : BaseService<Business, BusinessViewModel, BusinessBaseQueryModel>, IBusinessService
	{
		private readonly IFeedbackService feedbackService;
		private readonly IFeedbackRepository feedbackRepository;

		public BusinessService(IUnitOfWork unitOfWork, IBusinessRepository repository, IFeedbackService _feedbackService,
			IFeedbackRepository _feedbackRepository, IMapper mapper)
			: base(unitOfWork, repository, mapper)
		{
			feedbackService = _feedbackService;
			feedbackRepository = _feedbackRepository;
		}


		public async Task<IEnumerable<WorkerViewModel>> GetWorkers(Guid businessId)
		{
			var business = await Repository.GetFirstOrDefaultAsync(predicate: b => b.Id == businessId, disableTracking: false);
			return Mapper.Map<IEnumerable<WorkerViewModel>>(business.Workers);
		}

		public async Task<FeedbackViewModel> GiveFeedback(InsertFeedbackToBusinessQueryModel model)
		{
			var business = await Repository.GetByIdAsync(model.BusinessId);

			if (business == null)
				throw new BusinessLogicException("Business was not found with the provided Id.");
			if (!business.IsFeedbackAllowed)
				throw new BusinessLogicException("The worker with provided Id doesn't allow feedback.");

			return await feedbackService.Create(model);
		}

		public async Task<IEnumerable<FeedbackViewModel>> GetFeedbacks(Guid businessId)
		{
			var business = await Repository.GetByIdAsync(businessId);

			if (business == null)
				throw new BusinessLogicException("Business was not found with the provided Id.");

			return Mapper.Map<IEnumerable<FeedbackViewModel>>(business.Feedbacks);
		}

		public async Task DeleteFeedback(Guid id)
		{
			var feedback = await feedbackService.GetById(id);

			if (feedback == null)
				throw new BusinessLogicException("Feedback was not found with the provided Id.");

			await feedbackService.Delete(id);
		}

		public async Task<FeedbackViewModel> GetFeedback(Guid id)
		{
			var feedback = await feedbackService.GetById(id);

			if (feedback == null)
				throw new BusinessLogicException("Feedback was not found with the provided Id.");

			return feedback;
		}

		public async Task<FeedbackViewModel> EditFeedback(EditFeedbackQueryModel model)
		{
			var feedback = await feedbackRepository.GetByIdAsync(model.Id);

			if (feedback == null)
				throw new BusinessLogicException("Feedback was not found with the provided Id.");

			return await feedbackService.Update(model);
		}
	}
}
