using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application.DTOs;
using QueueManagementSystem.Application.Repositories;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueueManagementSystem.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : Controller
	{
		private readonly IRepositoryWrapper repo;
		private readonly IMapper mapper;

		public UserController(IRepositoryWrapper _repo, IMapper _mapper)
		{
			repo = _repo;
			mapper = _mapper;
		}
	}
}
