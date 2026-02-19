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
    }
}
