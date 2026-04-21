namespace Warthuneridle
{
    public interface IGame
    {
        public Task InitializeAsync();
        public List<GroundVehicle> LoadGroundVehicleData();
        public void Save(GroundVehicle vehicleToSave);
        public List<GroundVehicle> GroundVehicles();
    }
}
