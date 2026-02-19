namespace Warthuneridle.Components.Customs
{
    public partial class MainGame{
        private List<GroundVehicle> availableVehicles = new();
        private GroundVehicle targetVehicle;
        private List<GroundVehicle> guesses = new();
        private bool gameWon = false;

        protected override async Task OnInitializedAsync(){
            // Load vehicles from JSON
            availableVehicles = await LoadVehiclesFromJson();
            SelectRandomTarget();
        }

        private void HandleVehicleGuess(GroundVehicle guessedVehicle){
            guesses.Add(guessedVehicle);
            // will check more than only the name, probalby have some ID too
            if (guessedVehicle.VehicleName == targetVehicle.VehicleName){
                gameWon = true;
            }
        }

        private void ResetGame(){
            guesses.Clear();
            gameWon = false;
            SelectRandomTarget();
        }

        private void SelectRandomTarget(){
            var random = new Random();
            targetVehicle = availableVehicles[random.Next(availableVehicles.Count)];
        }

        private async Task<List<GroundVehicle>> LoadVehiclesFromJson(){
            // TODO: Implement JSON loading
            return new List<GroundVehicle>();
        }
    }
}
