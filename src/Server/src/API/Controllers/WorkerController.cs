using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application.DTOs;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueueManagementSystem.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class WorkerController : Controller
	{
		private readonly IRepositoryWrapper repo;
		private readonly IMapper mapper;

		public WorkerController(IRepositoryWrapper _repo, IMapper _mapper)
		{
			repo = _repo;
			mapper = _mapper;
		}

		#region GET
		[HttpGet]
		public async Task<ActionResult<Worker>> GetAll()
		{
			var workers = await repo.Workers.GetAllAsync();
			return Ok(mapper.Map<IEnumerable<WorkerDTO>>(workers));
		}

		[HttpGet("business/{businessId}")]
		public async Task<ActionResult<WorkerDTO>> GetBusinessWorkers(Guid businessId)
		{
			var business = await repo.Businesses.GetByIdAsync(businessId);
			if (business == null)
				return NotFound();
			var workers = await repo.Workers.GetAllAsync(w => w.BusinessId == businessId);
			return Ok(mapper.Map<IEnumerable<WorkerDTO>>(workers));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var worker = await repo.Workers.GetByIdAsync(id);
			if (worker is not null)
				return Ok(mapper.Map<WorkerDTO>(worker));
			return NotFound();
		}

		[HttpGet("getServices")]
		public async Task<ActionResult<WorkerServicesDTO>> GetWorkerServices([FromQuery] Guid workerId)
		{
			var worker = await repo.Workers.GetByIdAsync(workerId);
			return Ok(mapper.Map<WorkerServicesDTO>(worker));
		}
		#endregion

		#region POST
		[HttpPost]
		public async Task<IActionResult> Create(WorkerDTO worker)
		{
			Worker newWorker = mapper.Map<Worker>(worker);
			await repo.Workers.AddAsync(newWorker);
			await repo.SaveAsync();
			return CreatedAtAction(nameof(GetById), new { id = newWorker.Id }, mapper.Map<WorkerDTO>(newWorker));
		}

		[HttpPost("addService")]
		public async Task<IActionResult> AddService(AddServiceDTO addServiceDTO)
		{
			var serviceDetails = mapper.Map<ServiceDetails>(addServiceDTO);

			if (await repo.Services.GetByIdAsync(serviceDetails.ServiceId) == null)
				return BadRequest();

			var worker = await repo.Workers.GetByIdAsync(serviceDetails.WorkerId);
			worker.ServiceDetails.Add(serviceDetails);
			await repo.SaveAsync();

			return CreatedAtAction("GetById", "ServiceDetails", new { id = serviceDetails.Id }, mapper.Map<ServiceDetailsDTO>(serviceDetails));
		}
		#endregion

		#region DELETE
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			if (repo.Workers.Delete(id))
			{
				await repo.SaveAsync();
				return NoContent();
			}
			return NotFound();
		}
		#endregion

		#region PUT
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, WorkerDTO workerDTO)
		{
			if (id != workerDTO.Id)
				return BadRequest();
			if (await repo.Workers.GetByIdAsync(id) == null)
				return NotFound();

			var updatedWorker = mapper.Map<Worker>(workerDTO);
			repo.Workers.Update(updatedWorker);
			await repo.SaveAsync();
			return NoContent();
		}
		#endregion
	}
}
