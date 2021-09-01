using QueueManagementSystem.Application.Attributes;
using QueueManagementSystem.Domain.Entities;
using System;
using System.Text.Json.Serialization;

namespace QueueManagementSystem.Application.Users.QueryModels.Common
{
	public class UserQueryModel : UserBaseQueryModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }

		[JsonConverter(typeof(GenderConverter))]
		public Gender Gender { get; set; }

		[JsonConverter(typeof(ShortDateTimeConverter))]
		public DateTime Birthdate { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
	}
}
