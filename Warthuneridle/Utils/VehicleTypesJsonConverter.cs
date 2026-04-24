using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Warthuneridle.Models;

namespace Warthuneridle.Utils
{
    public class VehicleTypesJsonConverter : JsonConverter<VehicleTypes>
    {
        public override VehicleTypes? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var name = reader.GetString() ?? string.Empty;
                return VehicleTypes.GetFromName(name);
            }

            if (reader.TokenType == JsonTokenType.Null) return VehicleTypes.NULL;

            throw new JsonException($"Unexpected token parsing VehicleTypes: {reader.TokenType}");
        }

        public override void Write(Utf8JsonWriter writer, VehicleTypes value, JsonSerializerOptions options)
        {
            if (value is null) writer.WriteNullValue();
            else writer.WriteStringValue(value.Name);
        }
    }
}
