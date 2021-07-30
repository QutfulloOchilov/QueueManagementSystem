using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application.QueryModels;
using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Application.ViewModel;
using QueueManagementSystem.Application.ViewModels;
using QueueManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueueManagementSystem.API.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	public class BaseController<TEntity, TViewModel, TQueryModel, TService> : BaseEmptyController<TEntity, TViewModel, TQueryModel, TService>
	   where TEntity : class, IEntity
	   where TViewModel : BaseViewModel
	   where TQueryModel : BaseQueryModel
	   where TService : IService<TEntity, TViewModel, TQueryModel>
	{
		public BaseController(TService service) : base(service) { }

		[HttpGet]
		public Task<IEnumerable<TViewModel>> GetAll()
		{
			return Service.GetAll();
		}

		[HttpGet("pagedlist")]
		public async Task<ActionResult<PagedListViewModel<TViewModel>>> GetPagedList([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 20)
		{
			return Ok(await Service.GetPagedList(pageIndex, pageSize));
		}

		protected Task<TViewModel> GetEntityById(Guid id)
		{
			return Service.GetById(id);
		}

		protected virtual Task<TViewModel> Create([FromBody] TQueryModel createQueryModel)
		{
			return Service.Create(createQueryModel);
		}

		protected Task<TViewModel> Update([FromBody] TQueryModel updateQueryModel)
		{
			return Service.Update(updateQueryModel);
		}

		[HttpDelete("{id}")]
		public async virtual Task<IActionResult> Delete(Guid id)
		{
			await Service.Delete(id);
			return NoContent();
		}
	}
}
