using System.Collections.Generic;

namespace QueueManagementSystem.Application.Workers.ViewModels
{
	public class FreeTimeViewModel
	{
		public IEnumerable<TimeIntervalViewModel> TimeIntervals { get; set; }
	}
}
