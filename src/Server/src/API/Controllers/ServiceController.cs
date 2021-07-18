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
	public class ServiceController : Controller
	{
		private readonly IRepositoryWrapper repo;
		private readonly IMapper mapper;

		public ServiceController(IRepositoryWrapper _repo, IMapper _mapper)
		{
			repo = _repo;
			mapper = _mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetAll()
		{
			var services = await repo.Services.GetAllAsync();
			return Ok(mapper.Map<IEnumerable<ServiceDTO>>(services));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var service = await repo.Services.GetByIdAsync(id);
			if (service is not null)
				return NotFound();
			return Ok(mapper.Map<ServiceDTO>(service));
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			if (repo.Services.Delete(id))
				return NoContent();
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> Create(ServiceDTO serviceDTO)
		{
			var newService = mapper.Map<Service>(serviceDTO);
			await repo.Services.AddAsync(newService);
			await repo.SaveAsync();
			return CreatedAtAction(nameof(GetById), new { id = newService.Id }, mapper.Map<ServiceDTO>(newService));
		}
	}
}
