using Warthuneridle.Models.Wrapper;

namespace Warthuneridle
{
    public interface IGame
    {
        public Task InitializeAsync();
        public List<GroundVehicle> GroundVehicles();
        public DeserializedObjectWrapper LoadVehicleFromJson();
        public void Save(GroundVehicle vehicleToSave);
    }
}
