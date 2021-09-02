﻿using AutoMapper;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Feedbacks.QueryModels;
using QueueManagementSystem.Application.Feedbacks.Services;
using QueueManagementSystem.Application.Feedbacks.ViewModels;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Services
{
	public class FeedbackService : BaseService<Feedback, FeedbackViewModel, FeedbackBaseQueryModel>, IFeedbackService
	{
		public FeedbackService(IUnitOfWork unitOfWork, IFeedbackRepository repository, IMapper mapper)
			: base (unitOfWork, repository, mapper)
		{

		}
	}
}
