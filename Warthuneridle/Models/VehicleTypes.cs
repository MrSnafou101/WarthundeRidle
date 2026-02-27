using System.Text.Json.Serialization;

namespace Warthuneridle.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VehicleTypes{
        Medium,
        Heavy,
        Light,
        AA,
        ATGM_carrier,
        MBT,
        TD
    }
}
