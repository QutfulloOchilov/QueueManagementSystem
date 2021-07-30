﻿using System.Collections.Generic;

namespace QueueManagementSystem.API.Responses
{
	public class PropertyValidationErrorModel
	{
		public PropertyValidationErrorModel()
		{
			Messages = new List<string>();
		}

		public PropertyValidationErrorModel(string propertyName, IList<string> messages)
		{
			PropertyName = propertyName;
			Messages = messages;
		}

		public string PropertyName { get; set; }

		public IList<string> Messages { get; set; }
	}
}
