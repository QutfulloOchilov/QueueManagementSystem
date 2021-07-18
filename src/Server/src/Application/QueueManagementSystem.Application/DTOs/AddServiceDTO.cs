using System;

namespace QueueManagementSystem.Application.DTOs
{
	public class AddServiceDTO
	{
		public decimal Price { get; set; }
		public int Duration { get; set; }
		public Guid BusinessId { get; set; }
		public Guid WorkerId { get; set; }
		public Guid ServiceId { get; set; }
	}
}
