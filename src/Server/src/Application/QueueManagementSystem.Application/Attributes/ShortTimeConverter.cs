using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace QueueManagementSystem.Application.Attributes
{
    public class ShortTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var regex = new Regex("^[0-9]{2}:[0-9]{2}$");
            var time = reader.GetString();

            if (!(regex.IsMatch(reader.GetString()) &&
                  int.TryParse(time.Split(':')[0], out int hours) &&
                  int.TryParse(time.Split(':')[1], out int minutes)))
                throw new Exception("Invalid time value. Time format must be like {HH:mm}");

            return new DateTime(1, 1, 1, hours, minutes, 0);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToShortTimeString());
        }
    }
}