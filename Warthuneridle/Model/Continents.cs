using System.Text.Json.Serialization;

namespace Warthuneridle.Model
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
