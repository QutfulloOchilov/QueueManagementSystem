using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application.Businesses.QueryModels;
using QueueManagementSystem.Application.Businesses.QueryModels.Common;
using QueueManagementSystem.Application.Businesses.QueryModels.Insert;
using QueueManagementSystem.Application.Businesses.Services;
using QueueManagementSystem.Application.Businesses.ViewModels;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace QueueManagementSystem.API.Controllers
{
	public class BusinessController : BaseController<Business, BusinessViewModel, BusinessBaseQueryModel, IBusinessService>
	{
		public BusinessController(IBusinessService businessService) : base(businessService)
		{

		}

		[HttpGet("{id}")]
		public async Task<ActionResult<BusinessViewModel>> GetById(Guid id)
		{
			return Ok(await base.GetEntityById(id));
		}

		[HttpPost]
		public async Task<ActionResult<BusinessViewModel>> Create([FromBody] InsertBusinessQueryModel model)
		{
			return Ok(await base.Create(model));
		}

		[HttpPut]
		public async Task<ActionResult<BusinessViewModel>> Update([FromBody] BusinessQueryModel model)
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
