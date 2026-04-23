using Microsoft.AspNetCore.Components;
using Warthuneridle.Models;

namespace Warthuneridle.Components.Customs
{
    public partial class GroundForm
    {
        public GroundVehicle newGroundVehicle = new GroundVehicle();

        [Parameter]
        public EventCallback<GroundVehicle> OnVehicleCreated { get; set; }

        private void Reset()
        {
            newGroundVehicle = new GroundVehicle();
        }

        //private void CreateVehicle()
        //{
        //    // Id and PictureURL are ignored for now as requested
        //    // Ensure we pass a clone or a new instance to avoid accidental shared references
        //    var toSave = (GroundVehicle)newGroundVehicle.Clone();
        //    Game.Save(toSave);
        //    Reset();
        //}

        private async Task CreateVehicle(){
            await OnVehicleCreated.InvokeAsync(newGroundVehicle);
        }
    }
}
