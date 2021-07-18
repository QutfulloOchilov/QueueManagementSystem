using QueueManagementSystem.Domain.Entities;
using System;

namespace QueueManagementSystem.Application.DTOs
{
	public class WorkerDTO
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public Gender Gender { get; set; }
		public DateTime Birthdate { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public Guid BusinessId { get; set; }
	}
}
