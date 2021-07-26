using System.Collections.Generic;

namespace QueueManagementSystem.Domain.Entities
{
	public class Business : EntityBase
	{
		public Business()
		{
			//Workers = new List<Worker>();
			Feedbacks = new List<Feedback>();
		}
		public string Name { get; set; }
		public string Address { get; set; }
		//public virtual List<Worker> Workers { get; set; }
		public virtual List<Feedback> Feedbacks { get; set; }
	}
}
