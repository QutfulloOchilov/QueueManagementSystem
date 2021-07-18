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
	public class FeedbackController : Controller
	{
		private readonly IRepositoryWrapper repo;
		private readonly IMapper mapper;

		public FeedbackController(IRepositoryWrapper _repo, IMapper _mapper)
		{
			repo = _repo;
			mapper = _mapper;
		}

		#region GET
		[HttpGet("worker/{workerId}")]
		public async Task<ActionResult<IEnumerable<FeedbackDTO>>> GetWorkerFeedbacks(Guid userId, Guid workerId)
		{
			var feedbacks = await repo.Feedbacks.GetAllAsync(f => f.UserId == userId && f.WorkerId == workerId);
			return Ok(mapper.Map<IEnumerable<FeedbackDTO>>(feedbacks));
		}

		[HttpGet("business/{businessId}")]
		public async Task<ActionResult<IEnumerable<FeedbackDTO>>> GetBusinessFeedbacks(Guid businessId)
		{
			var feedbacks = await repo.Feedbacks.GetAllAsync(f => f.BusinessId == businessId);
			return Ok(mapper.Map<IEnumerable<FeedbackDTO>>(feedbacks));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<FeedbackDTO>> GetById(Guid id)
		{
			var feedback = await repo.Feedbacks.GetByIdAsync(id);
			return Ok(mapper.Map<FeedbackDTO>(feedback));
		}
		#endregion

		#region DELETE
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			repo.Feedbacks.Delete(id);
			await repo.SaveAsync();
			return NoContent();
		}
		#endregion

		#region POST
		[HttpPost]
		public async Task<IActionResult> Create(FeedbackDTO feedbackDTO)
		{
			var newFeedback = mapper.Map<Feedback>(feedbackDTO);
			await repo.Feedbacks.AddAsync(newFeedback);
			await repo.SaveAsync();
			return CreatedAtAction(nameof(GetById), new { id = newFeedback.Id }, mapper.Map<FeedbackDTO>(newFeedback));
		}
		#endregion
	}
}
