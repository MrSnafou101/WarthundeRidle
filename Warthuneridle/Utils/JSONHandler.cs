using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using Warthuneridle.Models;

namespace Warthuneridle.Utils
{
    public class JSONHandler : IJSONHandler
    {
        //public string groundVehicleFilePath = Environment.CurrentDirectory + @"\Resources\GroundVehiclesDataset.json";
        public string groundVehicleFilePath = AppContext.BaseDirectory + @"\Resources\GroundVehiclesDataset.json";
        //public string groundVehicleFilePath = Environment.CurrentDirectory + @"\Resources\VehicleTestDataset.json";

        public List<GroundVehicle> loadedGroundVehicles = new List<GroundVehicle>();
        private readonly JsonSerializerOptions options = new JsonSerializerOptions();
       
        public JSONHandler(){
        
            options.PropertyNameCaseInsensitive = true;
            options.WriteIndented =  true;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.Converters.Add(new JsonStringEnumConverter());
        }

        public async Task<DeserializedObjectWrapper> LoadVehicleDataAsync()
        {
            if (File.Exists(groundVehicleFilePath))
            {
                string jsonString = await File.ReadAllTextAsync(groundVehicleFilePath);
                DeserializedObjectWrapper dataset = JsonSerializer.Deserialize<DeserializedObjectWrapper>(jsonString, options)
                    ?? new DeserializedObjectWrapper();

                return dataset;
            }
            else
            {
                Console.WriteLine($"File not found: {groundVehicleFilePath}");
                return new DeserializedObjectWrapper();
            }
        }

        public DeserializedObjectWrapper LoadVehicleData()
        {
            if (File.Exists(groundVehicleFilePath))
            {
                string jsonString = File.ReadAllText(groundVehicleFilePath);

                DeserializedObjectWrapper  dataset = JsonSerializer.Deserialize<DeserializedObjectWrapper>(jsonString, options)
                    ?? new DeserializedObjectWrapper();

                return dataset;
            }
            else
            {
                Console.WriteLine($"File not found: {groundVehicleFilePath}");
                return new DeserializedObjectWrapper();
            }
        }
        public void Save(GroundVehicle vehicleToSave)
        {
            string updatedJsonString = string.Empty;

            if (loadedGroundVehicles == null || loadedGroundVehicles.Count <= 0){
                DeserializedObjectWrapper vehiclesToSave = LoadVehicleData();
                vehiclesToSave.Ground.Add(vehicleToSave);//To change
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