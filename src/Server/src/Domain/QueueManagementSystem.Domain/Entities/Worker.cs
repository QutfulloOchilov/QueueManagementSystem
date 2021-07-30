using System;
using System.Collections.Generic;

namespace QueueManagementSystem.Domain.Entities
{
	public class Worker : Person
	{
		public Worker()
		{
			ServiceDetails = new List<ServiceDetail>();
			Users = new List<User>();
			Feedbacks = new List<Feedback>();
			Reservations = new List<HaircutReservation>();
			WorkerSchedules = new List<WorkerSchedule>();
			Services = new List<Service>();
		}
		public virtual Business Business { get; set; }
		public Guid BusinessId { get; set; }
		public virtual List<ServiceDetail> ServiceDetails { get; set; }
		public virtual List<User> Users { get; set; }
		public virtual List<Feedback> Feedbacks { get; set; }
		public virtual List<HaircutReservation> Reservations { get; set; }
		public virtual List<WorkerSchedule> WorkerSchedules { get; set; }
		public virtual List<Service> Services { get; set; }
	}
}
