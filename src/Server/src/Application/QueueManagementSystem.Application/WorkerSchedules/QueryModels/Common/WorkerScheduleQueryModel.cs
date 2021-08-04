using QueueManagementSystem.Application.Attributes;
using System;
using System.Text.Json.Serialization;

namespace QueueManagementSystem.Application.WorkerSchedules.QueryModels.Common
{
	public class WorkerScheduleQueryModel : WorkerScheduleBaseQueryModel
	{
		[JsonConverter(typeof(DayOfWeekConverter))]
		public DayOfWeek DayOfWeek { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public Guid WorkerId { get; set; }
	}
}
