using Warthuneridle.Utils;

namespace Warthuneridle.Components.Pages
{
    public partial class MainGame{
        private List<GroundVehicle> availableVehicles = new();
        private GroundVehicle targetVehicle;
        private List<GroundVehicle> guesses = new();
        //private Dictionary<string, int> compareResults = new();
        private bool gameWon = false;

        protected override async Task OnInitializedAsync(){
            // Load vehicles from JSON
            availableVehicles = await LoadVehiclesFromJson();
            SelectRandomTarget();
            Console.WriteLine(targetVehicle.VehicleName);
        }

        private void HandleVehicleGuess(GroundVehicle guessedVehicle){
            guesses.Add(guessedVehicle);

            if (guessedVehicle.Equals(targetVehicle)) gameWon = true;
            //compareResults =  guessedVehicle.CompareVehicles(targetVehicle);
        }

        private void ResetGame(){
            guesses.Clear();
            gameWon = false;
            targetVehicle = null;
            SelectRandomTarget();
        }

        private void SelectRandomTarget(){
            var random = new Random();
            targetVehicle = availableVehicles[random.Next(availableVehicles.Count)];
        }

        private async Task<List<GroundVehicle>> LoadVehiclesFromJson(){
            
            JSONHandler jsonHandler = new JSONHandler();
            availableVehicles = jsonHandler.LoadGroundVehicleData();
            return availableVehicles;
        }
    }
}
