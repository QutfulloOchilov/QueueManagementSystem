using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Attributes
{
    public class GenderConverter : JsonConverter<Gender>
    {
        public override Gender Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetInt32() == 1 ? Gender.Male : Gender.Female;
        }

        public override void Write(Utf8JsonWriter writer, Gender value, JsonSerializerOptions options)
        {
            if (value == Gender.Male)
                writer.WriteStringValue("Мард");
            else
                writer.WriteStringValue("Зан");
        }
    }
}