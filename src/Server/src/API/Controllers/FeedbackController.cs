using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application.Feedbacks.QueryModels;
using QueueManagementSystem.Application.Feedbacks.QueryModels.Common;
using QueueManagementSystem.Application.Feedbacks.QueryModels.Insert;
using QueueManagementSystem.Application.Feedbacks.Services;
using QueueManagementSystem.Application.Feedbacks.ViewModels;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace QueueManagementSystem.API.Controllers
{
	public class FeedbackController : BaseController<Feedback, FeedbackViewModel, FeedbackBaseQueryModel, IFeedbackService>
	{
		public FeedbackController(IFeedbackService service) : base(service)
		{

		}

		[HttpGet("{id}")]
		public async Task<ActionResult<FeedbackViewModel>> GetById(Guid id)
		{
			return Ok(await base.GetEntityById(id));
		}

		[HttpPost]
		public async Task<ActionResult<FeedbackViewModel>> Create([FromBody] InsertFeedbackQueryModel model)
		{
			return Ok(await base.Create(model));
		}

		[HttpPut]
		public async Task<ActionResult<FeedbackViewModel>> Update([FromBody] FeedbackQueryModel model)
		{
			return Ok(await base.Update(model));
		}
	}
}
