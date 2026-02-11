using System.Text.Json;
using System.Text.Json.Serialization;

namespace Warthuneridle.Data
{
    public class JSONHandler
    {
        public string TestFilePath = Environment.CurrentDirectory + @"\Resources\VehicleTestDataset.json";
        public List<GroundVehicle> LoadGroundVehicles = new List<GroundVehicle>();

        public List<GroundVehicle> LoadGroundVehicleData()
        {
            if (File.Exists(TestFilePath))
            {
                string jsonString = File.ReadAllText(TestFilePath);
                LoadGroundVehicles = JsonSerializer.Deserialize<List<GroundVehicle>>(jsonString) ?? new List<GroundVehicle>();


                var options = new JsonSerializerOptions{
                    PropertyNameCaseInsensitive = true
                };
                options.Converters.Add(new JsonStringEnumConverter());

                LoadGroundVehicles = JsonSerializer.Deserialize<List<GroundVehicle>>(jsonString, options) ?? new List<GroundVehicle>();

                return LoadGroundVehicles;
            }
            else
            {
                Console.WriteLine($"File not found: {TestFilePath}");
                return null;
            }
        }

    }
}