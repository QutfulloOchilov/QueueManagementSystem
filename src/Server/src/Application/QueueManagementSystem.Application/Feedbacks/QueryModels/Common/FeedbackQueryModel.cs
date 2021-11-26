using System;
using System.Text.Json.Serialization;
using QueueManagementSystem.Application.Attributes;

namespace QueueManagementSystem.Application.Feedbacks.QueryModels.Common
{
    public class FeedbackQueryModel : FeedbackBaseQueryModel
    {
        public Guid UserId { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))] public DateTime PostedDateTime { get; set; }

        public int Star { get; set; }
        public string Comment { get; set; }
    }
}