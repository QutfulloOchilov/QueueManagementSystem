using System;
using System.Text.Json.Serialization;
using QueueManagementSystem.Application.Attributes;
using QueueManagementSystem.Application.ViewModel;

namespace QueueManagementSystem.Application.Workers.ViewModels
{
    public class WorkerReservationViewModel : BaseViewModel
    {
        [JsonConverter(typeof(ShortDateTimeConverter))] public DateTime From { get; set; }

        [JsonConverter(typeof(ShortDateTimeConverter))] public DateTime To { get; set; }

        public string UserName { get; set; }
        public decimal Price { get; set; }
    }
}