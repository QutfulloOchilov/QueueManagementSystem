using QueueManagementSystem.Application.Attributes;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Text.Json.Serialization;

namespace QueueManagementSystem.Application.Workers.ViewModels
{
	public class TimeIntervalViewModel
	{
		public TimeIntervalViewModel()
		{

		}

		public TimeIntervalViewModel(DateTime reservationDate, WorkerSchedule workerSchedule)
		{
			if (reservationDate == DateTime.Today && DateTime.Now >= workerSchedule.Start && DateTime.Now < workerSchedule.End)
				From = DateTime.Now;
			else
				From = new DateTime(reservationDate.Year, reservationDate.Month, reservationDate.Day, workerSchedule.Start.Hour, workerSchedule.Start.Minute, 0);

			To = new DateTime(reservationDate.Year, reservationDate.Month, reservationDate.Day, workerSchedule.End.Hour, workerSchedule.End.Minute, 0);
		}

		[JsonConverter(typeof(ShortDateTimeConverter))]
		public DateTime From { get; set; }

		[JsonConverter(typeof(ShortDateTimeConverter))]
		public DateTime To { get; set; }
	}
}
