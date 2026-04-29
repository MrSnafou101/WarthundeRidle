using Warthuneridle.Models.Wrapper;

namespace Warthuneridle.Utils
{
    public interface IJSONHandler
    {
        public Task<DeserializedObjectWrapper> LoadVehicleDataAsync();
        public DeserializedObjectWrapper LoadVehicleData();
        public void Save(GroundVehicle vehicleToSave);
    }
}
