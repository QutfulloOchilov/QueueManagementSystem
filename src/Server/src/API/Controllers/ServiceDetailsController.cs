using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application.DTOs;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace QueueManagementSystem.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ServiceDetailsController : Controller
	{
		private readonly IRepositoryWrapper repo;
		private readonly IMapper mapper;

		public ServiceDetailsController(IRepositoryWrapper _repo, IMapper _mapper)
		{
			repo = _repo;
			mapper = _mapper;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceDetailsDTO>> GetById(Guid id)
		{
			var serviceDetail = await repo.ServiceDetails.GetByIdAsync(id);
			if (serviceDetail == null)
				return NotFound();
			return Ok(mapper.Map<ServiceDetailsDTO>(serviceDetail));
		}
	}
}
