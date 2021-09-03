using QueueManagementSystem.Application.Attributes;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Text.Json.Serialization;

namespace QueueManagementSystem.Application.Workers.QueryModels.Common
{
    public class WorkerQueryModel : WorkerBaseQueryModel
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
		public Guid BusinessId { get; set; }
	}
}
