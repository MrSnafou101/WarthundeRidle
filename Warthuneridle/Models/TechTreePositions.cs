using System.Text.Json.Serialization;

namespace Warthuneridle.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TechTreePositions{
        Premium,
        Squadron,
        TechTree
    }
}
