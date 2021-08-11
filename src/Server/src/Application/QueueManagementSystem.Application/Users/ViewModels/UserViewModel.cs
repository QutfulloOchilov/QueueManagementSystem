using QueueManagementSystem.Application.ViewModel;
using QueueManagementSystem.Domain.Entities;
using System;

namespace QueueManagementSystem.Application.Users.ViewModels
{
	public class UserViewModel : BaseViewModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public Gender Gender { get; set; }
		public DateTime Birthdate { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
	}
}
