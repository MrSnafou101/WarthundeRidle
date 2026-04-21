using System.Text.Json;
using System.Text.Json.Serialization;

namespace Warthuneridle.Utils
{
    public class JSONHandler : IJSONHandler
    {
        //public string groundVehicleFilePath = Environment.CurrentDirectory + @"\Resources\GroundVehiclesDataset.json";
        public string groundVehicleFilePath = AppContext.BaseDirectory + @"\Resources\GroundVehiclesDataset.json";
        //public string TestFilePath = Environment.CurrentDirectory + @"\Resources\VehicleTestDataset.json";

        public List<GroundVehicle> loadedGroundVehicles = new List<GroundVehicle>();
        private readonly JsonSerializerOptions options = new JsonSerializerOptions();
       
        public JSONHandler(){
        
            options.PropertyNameCaseInsensitive = true;
            options.WriteIndented =  true;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.Converters.Add(new JsonStringEnumConverter());
        }

        public List<GroundVehicle> LoadGroundVehicleData()
        {
            if (File.Exists(groundVehicleFilePath))
            {
                string jsonString = File.ReadAllText(groundVehicleFilePath);

                loadedGroundVehicles = JsonSerializer.Deserialize<List<GroundVehicle>>(jsonString, options) ?? new List<GroundVehicle>();

                return loadedGroundVehicles;
            }
            else
            {
                Console.WriteLine($"File not found: {groundVehicleFilePath}");
                return loadedGroundVehicles;
            }
        }
        public void Save(GroundVehicle vehicleToSave)
        {
            string updatedJsonString = string.Empty;

            if (loadedGroundVehicles == null || loadedGroundVehicles.Count <= 0){
                List<GroundVehicle> vehiclesToSave = LoadGroundVehicleData();
                vehiclesToSave.Add(vehicleToSave);
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                updatedJsonString = JsonSerializer.Serialize(vehiclesToSave, options);
            }else{
                loadedGroundVehicles.Add(vehicleToSave);
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                updatedJsonString = JsonSerializer.Serialize(loadedGroundVehicles, options);
            }

            File.WriteAllText(groundVehicleFilePath, updatedJsonString);
        }
    }
}