using System;

namespace QueueManagementSystem.Domain.Entities
{
	public class ServiceDetail : EntityBase
	{
		public virtual Service Service { get; set; }
		public Guid ServiceId { get; set; }
		public virtual Worker Worker { get; set; }
		public Guid WorkerId { get; set; }
		public decimal Price { get; set; }
		public int Duration { get; set; }
	}
}
