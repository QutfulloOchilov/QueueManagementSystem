using System;

namespace QueueManagementSystem.Application.Workers.QueryModels
{
	public class DeleteServiceQueryModel
	{
		public Guid WorkerId { get; set; }
		public Guid ServiceDetailId { get; set; }
	}
}
