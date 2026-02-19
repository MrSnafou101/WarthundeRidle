using System.Text.Json.Serialization;

namespace Warthuneridle.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Continents{
        Europe,
        Asia,
        America,
        //NorthAmerica,
        //SouthAmerica,
        Africa,
        Oceania,
        Antarctica
    }
}
