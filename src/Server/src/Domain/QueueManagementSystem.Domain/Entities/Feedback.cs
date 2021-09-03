using System;

namespace QueueManagementSystem.Domain.Entities
{
	public class Feedback : EntityBase
	{
		public virtual Worker Worker { get; set; }
		public Guid? WorkerId { get; set; }
		public virtual Business Business { get; set; }
		public Guid? BusinessId { get; set; }
		public virtual User User { get; set; }
		public Guid UserId { get; set; }
		public DateTime PostedDateTime { get; set; }
		public string Comment { get; set; }
		public int Star { get; set; }
	}
}
