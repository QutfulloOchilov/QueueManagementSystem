﻿using QueueManagementSystem.Domain.Entities;
using System;

namespace QueueManagementSystem.Application.Users.QueryModels.Common
{
	public class UserQueryModel : UserBaseQueryModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public Gender Gender { get; set; }
		public DateTime Birthdate { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
	}
}
