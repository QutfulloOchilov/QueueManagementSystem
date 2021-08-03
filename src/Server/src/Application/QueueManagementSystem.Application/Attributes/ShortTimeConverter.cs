﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QueueManagementSystem.Application.Attributes
{
	public class ShortTimeConverter : JsonConverter<DateTime>
	{
		public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetDateTime();
		}

		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToShortTimeString());
		}
	}
}
