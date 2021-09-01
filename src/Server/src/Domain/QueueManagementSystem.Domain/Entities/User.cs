using System.Collections.Generic;

namespace QueueManagementSystem.Domain.Entities
{
	public class User : Person
	{
		public User()
		{
			Reservations = new List<HaircutReservation>();
			Feedbacks = new List<Feedback>();
			ServiceDetails = new List<ServiceDetail>();
		}

		public virtual List<HaircutReservation> Reservations { get; set; }
		public virtual List<Feedback> Feedbacks { get; set; }
		public virtual List<ServiceDetail> ServiceDetails { get; set; }
	}
}
