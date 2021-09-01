using System;

namespace QueueManagementSystem.Application.Users.QueryModels
{
	public class ReserveHaircutQueryModel
	{
		public Guid UserId { get; set; }
		public Guid JobDetailId { get; set; }
		public DateTime From { get; set; }
		public DateTime To { get; set; }
	}
}
