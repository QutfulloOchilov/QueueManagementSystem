using System;
using System.ComponentModel.DataAnnotations;

namespace QueueManagementSystem.Application.DTOs
{
	public class ReservationDTO
	{
		public WorkerDTO Worker { get; set; }
		public DateTime From { get; set; }
		public DateTime To { get; set; }
	}
}
