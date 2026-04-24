using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Warthuneridle.Models
{
    /*
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
        Fighter,
        Heavy_bomber,
        Frontline_bomber,
        Attacker,
        Interceptor,
        Battleship
    }
    */
    [JsonConverter(typeof(VehicleTypes))]
    public sealed class VehicleTypes {
        public static readonly VehicleTypes NULL = new VehicleTypes("Null", "");
        public static readonly VehicleTypes MEDIUM = new VehicleTypes("Medium", "ground");
        public static readonly VehicleTypes HEAVY = new VehicleTypes("Heavy", "ground");
        public static readonly VehicleTypes LIGHT = new VehicleTypes("Light", "ground");
        public static readonly VehicleTypes AA = new VehicleTypes("AA", "ground");
        public static readonly VehicleTypes ATGM_CARRIER = new VehicleTypes("ATGM carrier", "ground", "ATGM");
        public static readonly VehicleTypes MBT = new VehicleTypes("MBT", "ground");
        public static readonly VehicleTypes TD = new VehicleTypes("Tank Destroyer", "ground", "TD");
        public static readonly VehicleTypes FIGHTER = new VehicleTypes("Fighter", "air");
        public static readonly VehicleTypes HEAVY_BOMBER = new VehicleTypes("Heavy bomber", "air", "HB");
        public static readonly VehicleTypes FRONTLINE_BOMBER = new VehicleTypes("Frontline bomber", "air", "FB");
        public static readonly VehicleTypes ATTACKER = new VehicleTypes("Attacker", "air");
        public static readonly VehicleTypes INTERCEPTOR = new VehicleTypes("Interceptor", "air");
        public static readonly VehicleTypes BATTLESHIP = new VehicleTypes("Battleship", "naval");

        public string Name { get; private set; }
        public string? ShortName { get; private set; }
        public string ParentType { get; private set; }
        VehicleTypes(string name, string parentType, string? shortName = null) => (Name, ParentType, ShortName) = (name, parentType, shortName);

        public override string ToString() => Name;

        public static VehicleTypes GetFromName(string name) {
            foreach (var type in List())
            {
                if (string.Equals(type.Name, name, StringComparison.OrdinalIgnoreCase)) return type;
                else if(!string.IsNullOrEmpty(type.ShortName) && string.Equals(type.ShortName, name, StringComparison.OrdinalIgnoreCase)) return type;
            }
            return NULL;
        }

        public static IEnumerable<VehicleTypes> List() => new[] {
            NULL, MEDIUM, HEAVY, LIGHT, AA, ATGM_CARRIER, MBT, TD, FIGHTER,
            HEAVY_BOMBER, FRONTLINE_BOMBER, ATTACKER, INTERCEPTOR, BATTLESHIP
        };
        public static IEnumerable<VehicleTypes> ListGround() {
            List<VehicleTypes> groundTypes = new List<VehicleTypes>();
            groundTypes.Add(NULL);
            foreach (var type in List())
            {
                if (type.ParentType == "ground")groundTypes.Add(type);
            }
            return groundTypes;
        }
        public static IEnumerable<VehicleTypes> ListAir() {
            List<VehicleTypes> airTypes = new List<VehicleTypes>();
            airTypes.Add(NULL);
            foreach (var type in List())
            {
                if (type.ParentType == "air") airTypes.Add(type);
            }
            return airTypes;
        }
        public static IEnumerable<VehicleTypes> ListNaval() {
            List<VehicleTypes> navalTypes = new List<VehicleTypes>();
            navalTypes.Add(NULL);
            foreach (var type in List())
            {
                if (type.ParentType == "naval") navalTypes.Add(type);
            }
            return navalTypes;
        }
    }
}
