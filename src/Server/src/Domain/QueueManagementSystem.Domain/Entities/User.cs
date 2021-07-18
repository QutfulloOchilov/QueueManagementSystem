using System;
using System.Collections.Generic;

namespace QueueManagementSystem.Domain.Entities
{
	public class User : EntityBase
	{
		public User()
		{
			Reservations = new List<HaircutReservation>();
			Workers = new List<Worker>();
			Feedbacks = new List<Feedback>();
		}
		public string Login { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public Gender Gender { get; set; }
		public DateTime Birthdate { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string CardId { get; set; }
		public virtual List<HaircutReservation> Reservations { get; set; }
		public virtual List<Worker> Workers { get; set; }
		public virtual List<Feedback> Feedbacks { get; set; }

		public override string ToString() => $"{LastName} {FirstName} {MiddleName}";
	}

	public enum Gender
	{
		Female = 0,
		Male = 1
	}
}
