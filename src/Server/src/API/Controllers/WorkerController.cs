using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application.Workers.QueryModels;
using QueueManagementSystem.Application.Workers.QueryModels.Common;
using QueueManagementSystem.Application.Workers.QueryModels.Insert;
using QueueManagementSystem.Application.Workers.Services;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;
using System;
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

		[HttpPost]
		public async Task<ActionResult<WorkerViewModel>> Create([FromBody] InsertWorkerQueryModel model)
		{
			return Ok(await base.Create(model));
		}

		[HttpPut]
		public async Task<ActionResult<WorkerViewModel>> Update([FromBody] WorkerQueryModel model)
		{
			return Ok(await base.Update(model));
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(Guid id)
		{
			return await base.Delete(id);
		}
	}
}
