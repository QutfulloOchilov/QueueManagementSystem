using System;
using System.ComponentModel.DataAnnotations;

namespace QueueManagementSystem.Application.DTOs
{
	public class BusinessDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public bool IsActive { get; set; }
	}
}
