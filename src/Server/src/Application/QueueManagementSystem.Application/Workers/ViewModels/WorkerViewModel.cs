using QueueManagementSystem.Application.Attributes;
using QueueManagementSystem.Application.ViewModel;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Text.Json.Serialization;

namespace QueueManagementSystem.Application.Workers.ViewModels
{
	public class WorkerViewModel : BaseViewModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }

		[JsonConverter(typeof(GenderConverter))]
		public Gender Gender { get; set; }

		[JsonConverter(typeof(ShortDateTimeConverter))]
		public DateTime Birthdate { get; set; }
		public bool IsFeedbackAllowed { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
	}
}
