using System.Text.Json.Serialization;

namespace Warthuneridle.Model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VehicleTypes{
        Medium,
        Heavy,
        Light,
        AA,
        ATGM_carrier,
        MBT
    }
}
