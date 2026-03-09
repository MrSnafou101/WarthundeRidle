using Blazicons;
using Microsoft.AspNetCore.Components;
using Warthuneridle.Models;
using Warthuneridle.Utils;

namespace Warthuneridle.Components.Customs
{
    public partial class GuessRow
    {
        [Parameter]
        public GroundVehicle Guess { get; set; }

        [Parameter]
        public GroundVehicle TargetVehicle { get; set; }

        private Dictionary<string, int> CompareResults { get; set; }

        protected override void OnParametersSet(){
            if (CompareResults == null && Guess != null && TargetVehicle != null){
                CompareResults = Guess.CompareVehicles(TargetVehicle);
            }
        }

        // Helper used by the razor markup to read the stored compare value.
        public int GetCompareValue(string key){
            if (CompareResults != null && CompareResults.TryGetValue(key, out var v)) return v;

            return -1;
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

/**
 // Local snapshot of the compare results so that once a row is rendered
        // its visual hints don't change when the parent reuses/updates the
        // shared dictionary for subsequent guesses.
        private Dictionary<string, int> _localCompareResults;

        protected override void OnParametersSet()
        {
            // Only capture the compare results once per row. If the parent
            // reuses the same Dictionary instance for future guesses, older
            // rows keep their own copy and won't change their CSS.
            if (_localCompareResults == null && CompareResults != null)
            {
                _localCompareResults = new Dictionary<string, int>(CompareResults);
            }
        }

        public int GetCompareValue(string key)
        {
            if (_localCompareResults != null && _localCompareResults.TryGetValue(key, out var v))
                return v;

            if (CompareResults != null && CompareResults.TryGetValue(key, out var v2))
                return v2;

            return 0;
        }
 */