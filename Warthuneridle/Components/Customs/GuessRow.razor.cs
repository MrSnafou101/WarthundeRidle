using Microsoft.AspNetCore.Components;
using Warthuneridle.Models;

namespace Warthuneridle.Components.Customs
{
    public partial class GuessRow
    {
        [Parameter]
        public GroundVehicle Guess { get; set; }

        [Parameter]
        public GroundVehicle TargetVehicle { get; set; }

        public string ConvertMultipleMainGunAttr(int nbrOfguns) { 
            switch (nbrOfguns)
            {
                case 0:
                    return "No main gun";
                case 1:
                    return "1 Main gun";
                case 2:
                    return "2 or more main gun";
                default:
                    return "err";
            }
        }
    }
}
