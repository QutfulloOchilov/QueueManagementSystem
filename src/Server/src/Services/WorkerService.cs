using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Feedbacks.QueryModels;
using QueueManagementSystem.Application.Feedbacks.QueryModels.Insert;
using QueueManagementSystem.Application.Feedbacks.Services;
using QueueManagementSystem.Application.Feedbacks.ViewModels;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Application.Workers.QueryModels;
using QueueManagementSystem.Application.Workers.QueryModels.Insert;
using QueueManagementSystem.Application.Workers.Services;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Services
{
    public class WorkerService : BaseService<Worker, WorkerViewModel, WorkerBaseQueryModel>, IWorkerService
    {
        private readonly IFeedbackService feedbackService;
        private readonly IJobRepository jobRepo;
        private readonly IMapper mapper;
        private readonly IIdentityService identityService;

        public WorkerService(IUnitOfWork unitOfWork, IWorkerRepository repository, IJobRepository _jobRepo,
            IFeedbackService _feedbackService, IMapper _mapper, IIdentityService identityService)
            : base(unitOfWork, repository, _mapper)
        {
            feedbackService = _feedbackService;
            jobRepo = _jobRepo;
            mapper = _mapper;
            this.identityService = identityService;
        }

        public async Task AddJob(AddJobQueryModel model)
        {
            var worker = await Repository.GetByIdAsync(model.WorkerId);
            var job = await jobRepo.GetByIdAsync(model.JobId);

            if (job == null)
                throw new BusinessLogicException("Job was not found with a provided Id.");

            worker.JobDetails.Add(mapper.Map<JobDetail>(model));
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkerJobViewModel>> GetJobs(Guid workerId)
        {
            var worker = await Repository.GetByIdAsync(workerId);
            var jobs = worker.JobDetails;
            return mapper.Map<IEnumerable<JobDetail>, IEnumerable<WorkerJobViewModel>>(jobs);
        }

        public async Task UpdateJob(UpdateJobQueryModel model)
        {
            var worker = await Repository.GetByIdAsync(model.WorkerId);
            var jobDetail = worker.JobDetails.FirstOrDefault(sd => sd.Id == model.JobDetailId);
            if (jobDetail == null)
                throw new BusinessLogicException("Job was not found with a provided Id.");
            mapper.Map(model, jobDetail);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteJob(DeleteJobQueryModel model)
        {
            var worker = await Repository.GetByIdAsync(model.WorkerId);
            var jobDetail = worker.JobDetails.FirstOrDefault(sd => sd.Id == model.JobDetailId);
            if (jobDetail == null)
                throw new BusinessLogicException("Job was not found with a provided Id.");
            worker.JobDetails.Remove(jobDetail);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkerReservationViewModel>> GetReservations(Guid workerId)
        {
            List<HaircutReservation> reservations = new List<HaircutReservation>();
            var a = (await Repository.GetByIdAsync(workerId)).JobDetails;
            (await Repository.GetByIdAsync(workerId)).JobDetails.ForEach(sd =>
                reservations.AddRange(sd.HaircutReservations));

            return mapper.Map<IEnumerable<WorkerReservationViewModel>>(reservations);
        }

        public async Task<FeedbackViewModel> GiveFeedback(InsertFeedbackToWorkerQueryModel model)
        {
            var worker = await Repository.GetByIdAsync(model.WorkerId);

            if (worker == null)
                throw new BusinessLogicException("Worker was not found with the provided Id.");
            if (!worker.IsFeedbackAllowed)
                throw new BusinessLogicException("The worker with provided Id doesn't allow feedback.");

            return await feedbackService.Create(model);
        }

        public async Task<IEnumerable<FeedbackViewModel>> GetFeedbacks(Guid workerId)
        {
            var worker = await Repository.GetByIdAsync(workerId);

            if (worker == null)
                throw new BusinessLogicException("Worker was not found with the provided Id.");

            return Mapper.Map<IEnumerable<FeedbackViewModel>>(worker.Feedbacks);
        }

        public async Task<FeedbackViewModel> GetFeedback(Guid id)
        {
            var feedback = await feedbackService.GetById(id);

            if (feedback == null)
                throw new BusinessLogicException("Feedback was not found with the provided Id.");

            return feedback;
        }

        public async Task DeleteFeedback(Guid id)
        {
            var feedback = await feedbackService.GetById(id);

            if (feedback == null)
                throw new BusinessLogicException("Feedback was not found with the provided Id.");

            await feedbackService.Delete(id);
        }

        public async Task<FeedbackViewModel> EditFeedback(EditFeedbackQueryModel model)
        {
            var feedback = await feedbackService.GetById(model.Id);

            if (feedback == null)
                throw new BusinessLogicException("Feedback was not found with the provided Id.");

            return await feedbackService.Update(model);
        }

        public override async Task<WorkerViewModel> Create(WorkerBaseQueryModel newEntity)
        {
            if (newEntity is InsertWorkerQueryModel model)
            {
                var userAsync = await identityService.CreateUserAsync(model.Login, model.Email, model.Password);
                if (!userAsync.Result.Succeeded)
                {
                    throw new InvalidOperationException("Identity user has not been created");
                }

                newEntity.Id = Guid.Parse(userAsync.UserId);
                var workerViewModel = await base.Create(newEntity);
                return workerViewModel;
            }

            throw new InvalidOperationException($"{newEntity} is not {nameof(InsertWorkerQueryModel)}");
        }
    }
}