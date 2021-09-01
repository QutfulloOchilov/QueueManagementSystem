using QueueManagementSystem.Application.ViewModel;
using System;

namespace QueueManagementSystem.Application.Users.ViewModels
{
	public class UserReservationViewModel : BaseViewModel
	{
		public DateTime From { get; set; }
		public DateTime To { get; set; }
		public string WorkerName { get; set; }
		public decimal Price { get; set; }
	}
}
