using System;
using QueueManagementSystem.Application.Feedbacks.QueryModels.Common;

namespace QueueManagementSystem.Application.Feedbacks.QueryModels.Insert
{
    public class InsertFeedbackToBusinessQueryModel : FeedbackQueryModel
    {
        public Guid BusinessId { get; set; }
    }
}