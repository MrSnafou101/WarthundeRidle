using Microsoft.AspNetCore.Components;
using Warthuneridle.Models;

namespace Warthuneridle.Components.Customs
{
    public partial class GroundForm
    {
        public GroundVehicle newGroundVehicle;

        [Parameter]
        public EventCallback<GroundVehicle> OnVehicleCreated { get; set; }

        private async Task CreateVehicle(){
            GroundVehicle vehicle = new GroundVehicle();
            await OnVehicleCreated.InvokeAsync(vehicle);
        }
    }
}
