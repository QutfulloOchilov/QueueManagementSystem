using System;

namespace QueueManagementSystem.Application.Workers.QueryModels
{
	public class UpdateJobQueryModel
	{
		public Guid JobDetailId { get; set; }
		public decimal Price { get; set; }
		public int Duration { get; set; }
		public Guid WorkerId { get; set; }
	}
}
