using System;

namespace QueueManagementSystem.Domain.Entities
{
	public class WorkerSchedule : EntityBase
	{
		public DayOfWeek DayOfWeek { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public virtual Worker Worker { get; set; }
		public Guid WorkerId { get; set; }
	}
}
