using System;
using System.Collections.Generic;

namespace QueueManagementSystem.Domain.Entities
{
	public class Worker : Person
	{
		public Worker()
		{
			JobDetails = new List<JobDetail>();
			Feedbacks = new List<Feedback>();
			WorkerSchedules = new List<WorkerSchedule>();
			Jobs = new List<Job>();
		}
		public virtual Business Business { get; set; }
		public Guid BusinessId { get; set; }
		public bool IsFeedbackAllowed { get; set; }
		public virtual List<JobDetail> JobDetails { get; set; }
		public virtual List<Feedback> Feedbacks { get; set; }
		public virtual List<WorkerSchedule> WorkerSchedules { get; set; }
		public virtual List<Job> Jobs { get; set; }
	}
}
