using System;

namespace QueueManagementSystem.Domain.Entities
{
	public class HaircutReservation : EntityBase
	{
		public virtual User User { get; set; }
		public Guid UserId { get; set; }
		public virtual ServiceDetail ServiceDetail { get; set; }
		public Guid ServiceDetailId { get; set; }
		public DateTime From { get; set; }
		public DateTime To { get; set; }
	}
}
