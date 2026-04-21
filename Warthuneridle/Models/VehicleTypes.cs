using System.Text.Json.Serialization;

namespace Warthuneridle.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VehicleTypes{
        Null,
        Medium,
        Heavy,
        Light,
        AA,
        ATGM_carrier,
        MBT,
        TD,
        ERR,
        Fighter,
        Heavy_bomber,
        Frontline_bomber,
        Attacker,
        Interceptor
    }
}
