using QueueManagementSystem.Application.Attributes;
using System;
using System.Text.Json.Serialization;

namespace QueueManagementSystem.Application.Feedbacks.QueryModels.Common
{
	public class FeedbackQueryModel : FeedbackBaseQueryModel
	{
		public Guid WorkerId { get; set; }
		public Guid BusinessId { get; set; }
		public Guid UserId { get; set; }

		[JsonConverter(typeof(ShortDateTimeConverter))]
		public DateTime PostedDateTime { get; set; }
		public int Star { get; set; }
		public string Comment { get; set; }
	}
}
