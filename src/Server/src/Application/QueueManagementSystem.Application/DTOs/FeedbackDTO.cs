using System;

namespace QueueManagementSystem.Application.DTOs
{
	public class FeedbackDTO
	{
		public Guid Id { get; set; }
		public BusinessDTO Business { get; set; }
		public WorkerDTO Worker { get; set; }
		public UserDTO User { get; set; }
	}
}
