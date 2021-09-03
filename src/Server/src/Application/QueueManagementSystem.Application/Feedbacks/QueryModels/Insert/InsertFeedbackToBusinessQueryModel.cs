using QueueManagementSystem.Application.Feedbacks.QueryModels.Common;
using System;

namespace QueueManagementSystem.Application.Feedbacks.QueryModels.Insert
{
	public class InsertFeedbackToBusinessQueryModel : FeedbackQueryModel
	{
		public Guid BusinessId { get; set; }
	}
}
