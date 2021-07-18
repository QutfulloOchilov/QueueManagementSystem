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
	public class BusinessController : Controller
	{
		private readonly IRepositoryWrapper repo;
		private readonly IMapper mapper;

		public BusinessController(IRepositoryWrapper _repo, IMapper _mapper)
		{
			repo = _repo;
			mapper = _mapper;
		}

		#region GET
		[HttpGet]
		public async Task<ActionResult<IEnumerable<BusinessDTO>>> GetAll()
		{
			var businesses = await repo.Businesses.GetAllAsync();
			return Ok(mapper.Map<IEnumerable<BusinessDTO>>(businesses));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<BusinessDTO>> GetById(Guid id)
		{
			var business = await repo.Businesses.GetByIdAsync(id);
			if (business is not null)
				return Ok(mapper.Map<BusinessDTO>(business));
			return NotFound();
		}

		[HttpGet("getWorkers")]
		public async Task<ActionResult<IEnumerable<WorkerDTO>>> GetWorkers([FromHeader] Guid businessId)
		{
			var business = await repo.Businesses.GetByIdAsync(businessId);
			if (business == null)
				return BadRequest();
			return Ok(mapper.Map<IEnumerable<WorkerDTO>>(business.Workers));
		}
		#endregion

		#region POST
		[HttpPost]
		public async Task<IActionResult> Create(BusinessDTO business)
		{
			Business newBusiness = mapper.Map<BusinessDTO, Business>(business);
			await repo.Businesses.AddAsync(newBusiness);
			await repo.SaveAsync();
			return CreatedAtAction(nameof(GetById), new { id = newBusiness.Id }, mapper.Map<BusinessDTO>(newBusiness));
		}
		#endregion

		#region DELETE
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			if (repo.Businesses.Delete(id))
			{
				await repo.SaveAsync();
				return NoContent();
			}
			return NotFound();
		}
		#endregion

		#region PUT
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, BusinessDTO business)
		{
			if (id != business.Id)
				return BadRequest();

			if (await repo.Businesses.GetByIdAsync(id) == null)
				return NotFound();

			var updatedBusiness = mapper.Map<BusinessDTO, Business>(business);
			repo.Businesses.Update(updatedBusiness);
			await repo.SaveAsync();

			return NoContent();
		}
		#endregion
	}
}
