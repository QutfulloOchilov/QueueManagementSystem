using System.Collections.Generic;

namespace QueueManagementSystem.Domain.Entities
{
	public class Service : EntityBase
	{
		public Service()
		{
			ServiceDetails = new List<ServiceDetails>();
			Workers = new List<Worker>();
		}
		public string Name { get; set; }
		public virtual List<ServiceDetails> ServiceDetails { get; set; }
		public virtual List<Worker> Workers { get; set; }
	}
}
