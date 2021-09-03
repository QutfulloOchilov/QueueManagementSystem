using QueueManagementSystem.Application.Feedbacks.QueryModels.Common;
using System;

namespace QueueManagementSystem.Application.Feedbacks.QueryModels.Insert
{
	public class InsertFeedbackToWorkerQueryModel : FeedbackQueryModel
	{
		public Guid WorkerId { get; set; }
	}
}
