using System;

namespace QueueManagementSystem.Domain.Entities
{
	public class HaircutReservation : EntityBase
	{
		public virtual Worker Worker { get; set; }
		public Guid WorkerId { get; set; }
		public virtual User User { get; set; }
		public Guid UserId { get; set; }
		public DateTime From { get; set; }
		public DateTime To { get; set; }
	}
}
