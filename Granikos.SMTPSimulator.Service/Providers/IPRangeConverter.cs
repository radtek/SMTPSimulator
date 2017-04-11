using System;
using System.Net;
using Granikos.SMTPSimulator.Service.ConfigurationService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Granikos.SMTPSimulator.Service.Providers
{
    public class IPRangeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var range = (JsonIPRange)value;
            writer.WriteStartObject();
            writer.WritePropertyName("Start");
            writer.WriteValue(range.StartString);
            writer.WritePropertyName("End");
            writer.WriteValue(range.EndString);
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);

            return new JsonIPRange(IPAddress.Parse((string)obj["Start"]), IPAddress.Parse((string)obj["End"]));
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(JsonIPRange);
        }
    }
}