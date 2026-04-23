using Microsoft.AspNetCore.Components;
using Warthuneridle.Models;
using Warthuneridle.Utils;

namespace Warthuneridle.Components.Pages
{
    public partial class Settings
    {
        [Inject]
        public required IGame GameService { get; set; }

        public List<string> vehicleCategory = new List<string> { "Category", "Ground", "Air", "Naval" };
        public bool isCategorySelected = false;
        public string selectedCategory = "Category";

        public void OnCategorySelected()
        {
            switch (selectedCategory){
                case "Ground":
                    GroundSettings(selectedCategory);
                    break;
                case "Air":
                    AirSettings(selectedCategory);
                    break;
                case "Naval":
                    NavalSettings(selectedCategory);
                    break;
                case "category": isCategorySelected = false;
                    break;
                default: isCategorySelected = false;
                    break;
            }
        }

        private bool GroundSettings(string category)
        {
            //selectedCategory = "Ground";
            Console.WriteLine("Ground settings selected");
            isCategorySelected = true;
            return true;
        }
        private bool NavalSettings(string category)
        {
            //selectedCategory = "Naval";
            Console.WriteLine("Naval settings selected");
            isCategorySelected = true;
            return true;
        }

        private bool AirSettings(string category)
        {
            //selectedCategory = "Air";
            Console.WriteLine("Air settings selected");
            isCategorySelected = true;
            return true;
        }

        public void SaveNewVehicle(GroundVehicle vehicleToSave)
        {
            //GameService.Save(vehicleToSave);
            Console.WriteLine("Saving new vehicle of type => " + selectedCategory);
            Console.WriteLine(vehicleToSave);
        }

    }
}
