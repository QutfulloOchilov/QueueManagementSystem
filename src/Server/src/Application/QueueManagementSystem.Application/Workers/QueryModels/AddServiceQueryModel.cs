using System;

namespace QueueManagementSystem.Application.Workers.QueryModels
{
	public class AddServiceQueryModel
	{
		public Guid ServiceId { get; set; }
		public decimal Price { get; set; }
		public int Duration { get; set; }
		public Guid WorkerId { get; set; }
	}
}
