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
		private readonly IServiceRepository serviceRepo;
		private readonly IMapper mapper;

		public WorkerService(IUnitOfWork unitOfWork, IWorkerRepository repository, IServiceRepository _serviceRepo, IMapper _mapper)
			: base(unitOfWork, repository, _mapper)
		{
			serviceRepo = _serviceRepo;
			mapper = _mapper;
		}

		public async Task AddService(AddServiceQueryModel model)
		{
			var worker = await Repository.GetByIdAsync(model.WorkerId);
			var service = await serviceRepo.GetByIdAsync(model.ServiceId);

			if (service == null)
				throw new BusinessLogicException("Service was not found with a provided Id.");

			worker.ServiceDetails.Add(mapper.Map<ServiceDetail>(model));
			await UnitOfWork.SaveChangesAsync();
		}

		public async Task<IEnumerable<WorkerServiceViewModel>> GetServices(Guid workerId)
		{
			var worker = await Repository.GetByIdAsync(workerId);
			var services = worker.ServiceDetails;
			return mapper.Map<IEnumerable<ServiceDetail>, IEnumerable<WorkerServiceViewModel>>(services);
		}

		public async Task UpdateService(UpdateServiceQueryModel model)
		{
			var worker = await Repository.GetByIdAsync(model.WorkerId);
			var serviceDetail = worker.ServiceDetails.FirstOrDefault(sd => sd.Id == model.ServiceDetailId);
			if (serviceDetail == null)
				throw new BusinessLogicException("Service was not found with a provided Id.");
			mapper.Map(model, serviceDetail);
			await UnitOfWork.SaveChangesAsync();
		}

		public async Task DeleteService(DeleteServiceQueryModel model)
		{
			var worker = await Repository.GetByIdAsync(model.WorkerId);
			var serviceDetail = worker.ServiceDetails.FirstOrDefault(sd => sd.Id == model.ServiceDetailId);
			if (serviceDetail == null)
				throw new BusinessLogicException("Service was not found with a provided Id.");
			worker.ServiceDetails.Remove(serviceDetail);
			await UnitOfWork.SaveChangesAsync();
		}

		public async Task<IEnumerable<WorkerReservationViewModel>> GetReservations(Guid workerId)
		{
			List<HaircutReservation> reservations = new List<HaircutReservation>();
			var a = (await Repository.GetByIdAsync(workerId)).ServiceDetails;
			(await Repository.GetByIdAsync(workerId)).ServiceDetails.ForEach(sd => reservations.AddRange(sd.HaircutReservations));

			return mapper.Map<IEnumerable<WorkerReservationViewModel>>(reservations);
		}
	}
}
