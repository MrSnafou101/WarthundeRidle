using Blazicons;
using Microsoft.AspNetCore.Components;
using Warthuneridle.Models;
using Warthuneridle.Models.DicoKeys;
using Warthuneridle.Utils;

namespace Warthuneridle.Components.Customs
{
    public partial class GuessRow
    {
        [Parameter]
        public GroundVehicle Guess { get; set; }

        [Parameter]
        public GroundVehicle TargetVehicle { get; set; }

        // Helper used by the razor markup to read the stored compare value.
        public int GetCompareValue(string key){
            return Guess.GetstatComparaisonByStringKey(key.ToLower());
        }

        public SvgIcon getFlag() => Utils.FlagIconMapping.GetFlagIcon(Guess.Country.NationName);
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