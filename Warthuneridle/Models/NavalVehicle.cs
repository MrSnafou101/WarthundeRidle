using Warthuneridle.Models.DicoKeys;

namespace Warthuneridle.Models
{
    public class NavalVehicle : Vehicle
    {
        public NavalVehicle() { }
        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<VehicleStatsKeys, int> CompareVehicles(Vehicle target)
        {
            throw new NotImplementedException();
        }
    }
}