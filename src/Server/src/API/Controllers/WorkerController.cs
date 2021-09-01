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
		public async Task<ActionResult<IEnumerable<WorkerJobViewModel>>> GetJobs(Guid workerId)
		{
			return Ok(await Service.GetJobs(workerId));
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
		public async Task<IActionResult> AddJob([FromBody] AddJobQueryModel model)
		{
			await Service.AddJob(model);
			return Ok();
		}

		[HttpPut("[action]")]
		public async Task<IActionResult> UpdateJob([FromBody] UpdateJobQueryModel model)
		{
			await Service.UpdateJob(model);
			return Ok();
		}

		[HttpPut]
		public async Task<ActionResult<WorkerViewModel>> Update([FromBody] WorkerQueryModel model)
		{
			return Ok(await base.Update(model));
		}

		[HttpDelete("[action]")]
		public async Task<IActionResult> DeleteJob([FromBody] DeleteJobQueryModel model)
		{
			await Service.DeleteJob(model);
			return Ok();
		}
	}
}
