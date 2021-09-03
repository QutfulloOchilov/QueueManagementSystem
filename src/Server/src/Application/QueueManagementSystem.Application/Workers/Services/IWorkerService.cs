using QueueManagementSystem.Application.Feedbacks.QueryModels;
using QueueManagementSystem.Application.Feedbacks.QueryModels.Insert;
using QueueManagementSystem.Application.Feedbacks.ViewModels;
using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Application.Workers.QueryModels;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueueManagementSystem.Application.Workers.Services
{
	public interface IWorkerService : IService<Worker, WorkerViewModel, WorkerBaseQueryModel>
	{
		Task AddJob(AddJobQueryModel model);
		Task<IEnumerable<WorkerJobViewModel>> GetJobs(Guid workerId);
		Task UpdateJob(UpdateJobQueryModel model);
		Task DeleteJob(DeleteJobQueryModel model);
		Task<IEnumerable<WorkerReservationViewModel>> GetReservations(Guid workerId);
		Task<FeedbackViewModel> GiveFeedback(InsertFeedbackToWorkerQueryModel model);
		Task<IEnumerable<FeedbackViewModel>> GetFeedbacks(Guid workerId);
		Task<FeedbackViewModel> GetFeedback(Guid id);
		Task DeleteFeedback(Guid id);
		Task<FeedbackViewModel> EditFeedback(EditFeedbackQueryModel model);
	}
}
