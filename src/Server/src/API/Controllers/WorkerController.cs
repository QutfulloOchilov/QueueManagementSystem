using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application.Workers.QueryModels;
using QueueManagementSystem.Application.Workers.QueryModels.Common;
using QueueManagementSystem.Application.Workers.QueryModels.Insert;
using QueueManagementSystem.Application.Workers.Services;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueueManagementSystem.API.Controllers
{
	public class WorkerController : BaseController<Worker, WorkerViewModel, WorkerBaseQueryModel, IWorkerService>
	{
		public WorkerController(IWorkerService workerService) : base(workerService)
		{

		}

		[HttpGet("{id}")]
		public async Task<ActionResult<WorkerViewModel>> GetById(Guid id)
		{
			return Ok(await base.GetEntityById(id));
		}

		[HttpGet("[action]/{workerId}")]
		public async Task<ActionResult<IEnumerable<WorkerServiceViewModel>>> GetServices(Guid workerId)
		{
			return Ok(await Service.GetServices(workerId));
		}

		[HttpGet("[action]/{workerId}")]
		public async Task<ActionResult<IEnumerable<WorkerReservationViewModel>>> GetReservations(Guid workerId)
		{
			return Ok(await Service.GetReservations(workerId));
		}

		[HttpPost]
		public async Task<ActionResult<WorkerViewModel>> Create([FromBody] InsertWorkerQueryModel model)
		{
			return Ok(await base.Create(model));
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> AddService([FromBody] AddServiceQueryModel model)
		{
			await Service.AddService(model);
			return Ok();
		}

		[HttpPut("[action]")]
		public async Task<IActionResult> UpdateService([FromBody] UpdateServiceQueryModel model)
		{
			await Service.UpdateService(model);
			return Ok();
		}

		[HttpPut]
		public async Task<ActionResult<WorkerViewModel>> Update([FromBody] WorkerQueryModel model)
		{
			return Ok(await base.Update(model));
		}

		[HttpDelete("[action]")]
		public async Task<IActionResult> DeleteService([FromBody] DeleteServiceQueryModel model)
		{
			await Service.DeleteService(model);
			return Ok();
		}
	}
}
