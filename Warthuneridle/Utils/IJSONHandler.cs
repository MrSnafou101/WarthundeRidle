namespace Warthuneridle.Utils
{
    public interface IJSONHandler
    {
        public List<GroundVehicle> LoadGroundVehicleData();
        public void Save(GroundVehicle vehicleToSave);
    }
}
