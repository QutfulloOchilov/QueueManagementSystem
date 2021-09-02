using QueueManagementSystem.Application.ViewModel;
using System;

namespace QueueManagementSystem.Application.Feedbacks.ViewModels
{
	public class FeedbackViewModel : BaseViewModel
	{
		public DateTime PostedDateTime { get; set; }
		public int Star { get; set; }
		public string Comment { get; set; }
	}
}
