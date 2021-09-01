using System;

namespace QueueManagementSystem.Application.Workers.ViewModels
{
	public class WorkerServiceViewModel
	{
		public Guid ServiceDetailId { get; set; }
		public decimal Price { get; set; }
		public int Duration { get; set; }
		public string Name { get; set; }
	}
}
