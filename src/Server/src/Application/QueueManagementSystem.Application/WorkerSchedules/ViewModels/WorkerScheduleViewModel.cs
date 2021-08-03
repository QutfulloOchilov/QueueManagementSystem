using QueueManagementSystem.Application.Attributes;
using QueueManagementSystem.Application.ViewModel;
using System;
using System.Text.Json.Serialization;

namespace QueueManagementSystem.Application.WorkerSchedules.ViewModels
{
	public class WorkerScheduleViewModel : BaseViewModel
	{
		[JsonConverter(typeof(DayOfWeekConverter))]
		public DayOfWeek DayOfWeek { get; set; }
		
		[JsonConverter(typeof(ShortTimeConverter))]
		public DateTime Start { get; set; }
		
		[JsonConverter(typeof(ShortTimeConverter))]
		public DateTime End { get; set; }
	}
}
