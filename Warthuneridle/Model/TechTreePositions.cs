using System.Text.Json.Serialization;

namespace Warthuneridle.Model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TechTreePositions{
        Premium,
        Squadron,
        TechTree
    }
}
