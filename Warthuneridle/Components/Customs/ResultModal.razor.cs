using Microsoft.AspNetCore.Components;
using Warthuneridle.Models;


namespace Warthuneridle.Components.Customs
{
    public partial class ResultModal{
        [Parameter]
        public GroundVehicle VehicleFound { get; set; }

        [Parameter]
        public int NumberOfTries { get; set; }

        [Parameter]
        public EventCallback OnPlayAgain { get; set; }

        [Parameter]
        public EventCallback OnClose { get; set; }

        // Internal visibility state so the modal can hide itself when closed.
        private bool _visible = true;

        // Close the modal: hide locally and notify parent if a callback is provided.
        public async Task CloseModal()
        {
            _visible = false;
            await OnClose.InvokeAsync();
        }

    }
}
