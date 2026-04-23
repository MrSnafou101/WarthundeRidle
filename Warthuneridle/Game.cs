using Warthuneridle.Models;
using Warthuneridle.Utils;

namespace Warthuneridle
{
    public class Game(IJSONHandler jsonHandler) : IGame
    {
        private readonly IJSONHandler _jsonHandler = jsonHandler;
        private DeserializedObjectWrapper vehicles = new DeserializedObjectWrapper();

        public async Task InitializeAsync()
        {
            vehicles = await _jsonHandler.LoadVehicleDataAsync();
        }

        public List<GroundVehicle> GroundVehicles()
        {
            List<GroundVehicle> toReturn = new List<GroundVehicle>(vehicles.Ground.Count);

            vehicles.Ground.ForEach(v => {
                toReturn.Add((GroundVehicle)v.Clone());
            });

            return toReturn;
        }
        public List<AirVehicle> AirVehicles()
        {
            List<AirVehicle> toReturn = new List<AirVehicle>(vehicles.Air.Count);
            vehicles.Air.ForEach(v => {
                toReturn.Add((AirVehicle)v.Clone());
            });
            return toReturn;
        }
        public List<NavalVehicle> NavalVehicles()
        {
            List<NavalVehicle> toReturn = new List<NavalVehicle>(vehicles.Naval.Count);
            vehicles.Naval.ForEach(v => {
                toReturn.Add((NavalVehicle)v.Clone());
            });
            return toReturn;
        }

        public DeserializedObjectWrapper LoadVehicleFromJson()
        {
            return this._jsonHandler.LoadVehicleData();
        }

        public void Save(GroundVehicle vehicleToSave)
        {
            this._jsonHandler.Save(vehicleToSave);
        }

    }
}
