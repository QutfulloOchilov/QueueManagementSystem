using QueueManagementSystem.Domain.Entities;
using System;
using System.Text.Json;

namespace QueueManagementSystem.Application.Attributes
{
    public class GenderConverter : System.Text.Json.Serialization.JsonConverter<Gender>
    {
        public override Gender Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() == "Мард" || reader.GetString() == "1" ? Gender.Male : Gender.Female;
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
