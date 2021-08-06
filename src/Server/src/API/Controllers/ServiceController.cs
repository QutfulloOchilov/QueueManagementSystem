using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application._Services.QueryModels;
using QueueManagementSystem.Application._Services.QueryModels.Common;
using QueueManagementSystem.Application._Services.QueryModels.Insert;
using QueueManagementSystem.Application._Services.Services;
using QueueManagementSystem.Application._Services.ViewModels;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace QueueManagementSystem.API.Controllers
{
	public class ServiceController : BaseController<Service, ServiceViewModel, ServiceBaseQueryModel, IServiceService>
	{
		public ServiceController(IServiceService service) : base(service)
		{

		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceViewModel>> GetById(Guid id)
		{
			return Ok(await base.GetEntityById(id));
		}

		[HttpPost]
		public async Task<ActionResult<ServiceViewModel>> Create([FromBody] InsertServiceQueryModel model)
		{
			return Ok(await base.Create(model));
		}

		[HttpPut]
		public async Task<ActionResult<ServiceViewModel>> Update([FromBody] ServiceQueryModel model)
		{
			return Ok(await base.Update(model));
		}
	}
}
