using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QueueManagementSystem.Application.Attributes
{
    public class DayOfWeekConverter : JsonConverter<DayOfWeek>
    {
        public override DayOfWeek Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() switch
            {
                "Якшанбе" => DayOfWeek.Sunday,
                "Душанбе" => DayOfWeek.Monday,
                "Сешанбе" => DayOfWeek.Tuesday,
                "Чоршанбе" => DayOfWeek.Wednesday,
                "Панчшанбе" => DayOfWeek.Thursday,
                "Чумъа" => DayOfWeek.Friday,
                "Шанбе" => DayOfWeek.Saturday,
            };
        }

        public override void Write(Utf8JsonWriter writer, DayOfWeek value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case DayOfWeek.Sunday:
                    writer.WriteStringValue("Якшанбе");
                    break;
                case DayOfWeek.Monday:
                    writer.WriteStringValue("Душанбе");
                    break;
                case DayOfWeek.Tuesday:
                    writer.WriteStringValue("Сешанбе");
                    break;
                case DayOfWeek.Wednesday:
                    writer.WriteStringValue("Чоршанбе");
                    break;
                case DayOfWeek.Thursday:
                    writer.WriteStringValue("Панчшанбе");
                    break;
                case DayOfWeek.Friday:
                    writer.WriteStringValue("Чумъа");
                    break;
                case DayOfWeek.Saturday:
                    writer.WriteStringValue("Шанбе");
                    break;
            }
        }
    }
}