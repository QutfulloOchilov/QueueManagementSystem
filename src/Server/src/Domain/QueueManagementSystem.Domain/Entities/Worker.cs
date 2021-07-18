﻿using System;
using System.Collections.Generic;

namespace QueueManagementSystem.Domain.Entities
{
	public class Worker : EntityBase
	{
		public Worker()
		{
			ServiceDetails = new List<ServiceDetails>();
			Feedbacks = new List<Feedback>();
			Reservations = new List<HaircutReservation>();
			WorkerSchedules = new List<WorkerSchedule>();
			Users = new List<User>();
			Services = new List<Service>();
		}
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public Gender Gender { get; set; }
		public DateTime Birthdate { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public virtual Business Business { get; set; }
		public Guid BusinessId { get; set; }
		public virtual List<ServiceDetails> ServiceDetails { get; set; }
		public virtual List<User> Users { get; set; }
		public virtual List<Feedback> Feedbacks { get; set; }
		public virtual List<HaircutReservation> Reservations { get; set; }
		public virtual List<WorkerSchedule> WorkerSchedules { get; set; }
		public virtual List<Service> Services { get; set; }
	}
}
