using Microsoft.AspNetCore.Components;
using Warthuneridle.Utils;

namespace Warthuneridle.Components.Pages
{
    public partial class MainGame{

        [Inject]
        public required IGame GameService { get; set; }

        private List<GroundVehicle> availableVehicles = new();
        private GroundVehicle? targetVehicle;
        private List<GroundVehicle> guesses = new();
        //private Dictionary<string, int> compareResults = new();
        private bool gameWon = false;

        protected override async Task OnInitializedAsync(){
            // Load vehicles from JSON
            availableVehicles = GameService.GroundVehicles();
            SelectRandomTarget();
            Console.WriteLine(targetVehicle.VehicleName);
        }

        private void HandleVehicleGuess(GroundVehicle guessedVehicle){
            guesses.Add(guessedVehicle);

            if (guessedVehicle.Equals(targetVehicle)) gameWon = true;
            guessedVehicle.CompareVehicles(targetVehicle);
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
    }
}
