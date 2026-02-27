using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace Warthuneridle.Components.Customs
{
    public partial class SearchBar
    {
        public string SearchTerm { get; set; } = string.Empty;
        [Parameter]
        public List<GroundVehicle> AvailableVehicles { get; set; } = new();

        [Parameter]
        public EventCallback<GroundVehicle> OnVehicleSelected { get; set; }

        private string searchText = "";
        private bool showSuggestions = false;
        private List<GroundVehicle> filteredVehicles = new();

        // Regex pattern: only letters, digits, spaces, underscores, and dashes
        //^[a-zA-Z0-9 _-]+$
        private readonly Regex validInputPattern = new Regex(@"[a-zA-Z0-9 _\-\(\)]");

        protected override void OnParametersSet()
        {
            FilterVehicles();
        }

        private void FilterVehicles()
        {

            // Auto-strip invalid characters - keep only valid ones
            if (!string.IsNullOrWhiteSpace(searchText)){
                var matches = validInputPattern.Matches(searchText);
                searchText = string.Concat(matches.Select(m => m.Value));
            }

            if (string.IsNullOrWhiteSpace(searchText)){
                filteredVehicles = AvailableVehicles.Take(10).ToList();
            }
            else{
                filteredVehicles = AvailableVehicles
                    .Where(v => v.VehicleName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                               v.Country.NationName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                               v.VehicleType.ToString().Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    .Take(10).ToList();
            }
        }

        private void ShowSuggestions(){
            showSuggestions = true;
        }

        private void HideSuggestions(){
            Task.Delay(200).ContinueWith(_ =>{
                showSuggestions = false;
                InvokeAsync(StateHasChanged);
            });
        }

        private async Task SelectVehicle(GroundVehicle vehicle){
            searchText = "";
            showSuggestions = false;
            await OnVehicleSelected.InvokeAsync(vehicle);
        }
    }
}
