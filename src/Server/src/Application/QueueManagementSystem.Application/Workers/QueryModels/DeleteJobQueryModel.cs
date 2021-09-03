using System;

namespace QueueManagementSystem.Application.Workers.QueryModels
{
	public class DeleteJobQueryModel
	{
		public Guid WorkerId { get; set; }
		public Guid JobDetailId { get; set; }
	}
}
