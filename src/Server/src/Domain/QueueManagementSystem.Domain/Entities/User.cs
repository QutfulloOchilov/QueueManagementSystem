using System.Collections.Generic;

namespace QueueManagementSystem.Domain.Entities
{
	public class User : Person
	{
		public User()
		{
			Reservations = new List<HaircutReservation>();
			Workers = new List<Worker>();
			Feedbacks = new List<Feedback>();
		}
		public virtual List<HaircutReservation> Reservations { get; set; }
		public virtual List<Worker> Workers { get; set; }
		public virtual List<Feedback> Feedbacks { get; set; }
	}
}
