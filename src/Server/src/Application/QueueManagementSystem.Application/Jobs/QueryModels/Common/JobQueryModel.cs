using System;

namespace QueueManagementSystem.Application.Jobs.QueryModels.Common
{
	public class JobQueryModel : JobBaseQueryModel
	{
		public string Name { get; set; }
		public Guid CategoryId { get; set; }
	}
}
