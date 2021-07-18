using System;

namespace QueueManagementSystem.Application.DTOs
{
	public class ServiceDetailsDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Duration { get; set; }
		public Guid ServiceId { get; set; }
	}
}
