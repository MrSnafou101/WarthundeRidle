using Warthuneridle.Utils;

namespace Warthuneridle
{
    public class Game : IGame
    {
        private List<GroundVehicle> groundVehicles = new List<GroundVehicle>();
        //private List<AirVehicle> airVehicles = new List<AirVehicle>();
        //private List<NavalVehicle> navalVehicles = new List<NavalVehicle>();
        public JSONHandler jsonHandler  = new JSONHandler();

        public async Task InitializeAsync()
        {
            groundVehicles = jsonHandler.LoadGroundVehicleData();
        }

        public List<GroundVehicle> GroundVehicles()
        {
            List<GroundVehicle> toReturn = new List<GroundVehicle>(groundVehicles.Count);

            groundVehicles.ForEach(v => {
                toReturn.Add((GroundVehicle)v.Clone());
            });

            return toReturn;
        }


        public List<GroundVehicle> LoadGroundVehicleData()
        {
            throw new NotImplementedException();
        }

        public void Save(GroundVehicle vehicleToSave)
        {
            throw new NotImplementedException();
        }

    }
}
