using AutoMapper;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Application.Workers.QueryModels;
using QueueManagementSystem.Application.Workers.Services;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueueManagementSystem.Services
{
	public class WorkerService : BaseService<Worker, WorkerViewModel, WorkerBaseQueryModel>, IWorkerService
	{
		private readonly IJobRepository jobRepo;
		private readonly IMapper mapper;

		public WorkerService(IUnitOfWork unitOfWork, IWorkerRepository repository, IJobRepository _jobRepo, IMapper _mapper)
			: base(unitOfWork, repository, _mapper)
		{
			jobRepo = _jobRepo;
			mapper = _mapper;
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
			(await Repository.GetByIdAsync(workerId)).JobDetails.ForEach(sd => reservations.AddRange(sd.HaircutReservations));

			return mapper.Map<IEnumerable<WorkerReservationViewModel>>(reservations);
		}
	}
}
