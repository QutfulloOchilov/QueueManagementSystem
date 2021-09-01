using QueueManagementSystem.Application.Attributes;
using System;
using System.Text.Json.Serialization;

namespace QueueManagementSystem.Application.WorkerSchedules.QueryModels.Common
{
	public class WorkerScheduleQueryModel : WorkerScheduleBaseQueryModel
	{
		[JsonConverter(typeof(DayOfWeekConverter))]
		public DayOfWeek DayOfWeek { get; set; }
		
		[JsonConverter(typeof(ShortTimeConverter))]
		public DateTime Start { get; set; }

		[JsonConverter(typeof(ShortTimeConverter))]
		public DateTime End { get; set; }
		public Guid WorkerId { get; set; }
	}
}
