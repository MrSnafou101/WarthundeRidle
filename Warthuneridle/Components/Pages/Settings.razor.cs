using Warthuneridle.Models;
using Warthuneridle.Utils;

namespace Warthuneridle.Components.Pages
{
    public partial class Settings
    {
        private Vehicle vehicleToAdd;
        public List<string> vehicleCategory = new List<string> { "category", "Ground", "Air", "Naval" };
        public bool isCategorySelected = false;
        public string selectedCategory = "category";

        public bool OnCategorySelected(string category) => category switch
        {
            "Ground" => GroundSettings(category),
            "Air" => AirSettings(category),
            "Naval" => NavalSettings(category),
            "category" => isCategorySelected = false,
            _ => isCategorySelected = false
        };

        private bool GroundSettings(string category)
        {
            selectedCategory = "Ground";
            return true;
        }
        private bool NavalSettings(string category)
        {
            selectedCategory = "Naval";
            return true;
        }

        private bool AirSettings(string category)
        {
            selectedCategory = "Air";
            return true;
        }

        public void SaveNewVehicle(GroundVehicle vehicleToSave)
        {
            new JSONHandler().save(vehicleToSave);
            Console.WriteLine("Saving new vehicle of type => " + selectedCategory);
        }

    }
}
