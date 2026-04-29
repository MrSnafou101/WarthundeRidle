namespace Warthuneridle.Models.Wrapper
{
    public class DeserializedObjectWrapper
    {
        public List<GroundVehicle> Ground { get; set; } = new List<GroundVehicle> ();
        public List<AirVehicle> Air { get; set; } = new List<AirVehicle> ();
        public List<NavalVehicle> Naval { get; set; } = new List<NavalVehicle> ();
    }
}
