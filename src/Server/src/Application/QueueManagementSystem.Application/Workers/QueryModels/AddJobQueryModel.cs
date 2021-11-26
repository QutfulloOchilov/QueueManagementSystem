using System;

namespace QueueManagementSystem.Application.Workers.QueryModels
{
    public class AddJobQueryModel
    {
        public Guid JobId { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public Guid WorkerId { get; set; }
    }
}