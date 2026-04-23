using Warthuneridle.Models;

namespace Warthuneridle.Utils
{
    public interface IJSONHandler
    {
        public Task<DeserializedObjectWrapper> LoadVehicleDataAsync();
        public DeserializedObjectWrapper LoadVehicleData();
        public void Save(GroundVehicle vehicleToSave);
    }
}
