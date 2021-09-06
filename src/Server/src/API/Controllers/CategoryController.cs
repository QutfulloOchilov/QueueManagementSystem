using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application.Categories.QueryModels;
using QueueManagementSystem.Application.Categories.QueryModels.Common;
using QueueManagementSystem.Application.Categories.QueryModels.Insert;
using QueueManagementSystem.Application.Categories.Services;
using QueueManagementSystem.Application.Categories.ViewModels;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace QueueManagementSystem.API.Controllers
{
	public class CategoryController : BaseController<Category, CategoryViewModel, CategoryBaseQueryModel, ICategoryService>
	{
		public CategoryController(ICategoryService service) : base(service)
		{

		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CategoryViewModel>> GetById(Guid id)
		{
			return Ok(await base.GetEntityById(id));
		}

		[HttpPost]
		public async Task<ActionResult<CategoryViewModel>> Create([FromBody] InsertCategoryQueryModel model)
		{
			return Ok(await base.Create(model));
		}

		[HttpPut]
		public async Task<ActionResult<CategoryViewModel>> Update([FromBody] CategoryQueryModel model)
		{
			return Ok(await base.Update(model));
		}
	}
}
