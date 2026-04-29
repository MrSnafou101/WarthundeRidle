using System.ComponentModel.DataAnnotations;
using Warthuneridle.Models.DicoKeys;

namespace Warthuneridle.Models
{
    public abstract class Vehicle: ICloneable
    {
        public int VehicleId { get; set; } = 0; //may change to UUID later

        [Display(Name = "Vehicle Name")]
        [RegularExpression(@"[a-zA-Z0-9 _\-\(\)]+", ErrorMessage = "Some characters are not allowed.")]
        public string VehicleName { get; set; } = "vehicle name";

        public string? PictureURL { get; set; }

        [Display(Name = "Vehicle Type")]
        public VehicleTypes VehicleType { get; set; } = VehicleTypes.NULL;

        public Nation Country { get; set; } = new Nation();

        public VehicleRank Rank { get; set; } = new VehicleRank();

        [Display(Name = "Position in the Techtree")]
        public TechTreePositions TechTreePosition { get; set; } = TechTreePositions.Null;

        [Display(Name = "Main gun caliber")]
        [Range(0, 800, ErrorMessage = "Main gun caliber must be between 0 and 800mm")]
        public double MainGunCaliber { get; set; }

        public Dictionary<VehicleStatsKeys, int>? ComparisonResults { get; set; }

        public abstract Dictionary<VehicleStatsKeys, int> CompareVehicles(Vehicle target);
        public abstract object Clone();
        public int GetstatComparaisonByStringKey(string key){
            if (Enum.TryParse(typeof(VehicleStatsKeys), key, out var v)){
                if (this.ComparisonResults != null && this.ComparisonResults.TryGetValue((VehicleStatsKeys)v, out var res)) return res;
                else return -1;
            }
            else{
                return -1;
            }
        }
        public int IsSameTechTreePosition(TechTreePositions toCheckTechTreePosition)
        {
            if (this.TechTreePosition == toCheckTechTreePosition) return 1;
            else return 0;
        }
        public int isSameVehicleType(VehicleTypes toCheckVehicleType)
        {
            if (this.VehicleType == toCheckVehicleType) return 1;
            else return 0;
        }

        /// <summary>
        /// Check main gun caliber to see if they are the same or at least within the same range.
        /// </summary>
        /// <param name="toCheckCaliber">Gun caliber to compare with</param>
        /// <returns>
        /// return 1 if the caliber is the same,
        /// return 2 if the caliber is not the same but within the same range,
        /// return 0 if the caliber isn't the same nor within the same range
        /// </returns>
        public int IsSameCaliber(int toCheckCaliber)
        {
            int[] caliberRange = GetCaliberRange();
            if (this.MainGunCaliber == toCheckCaliber) return 1;
            else if (caliberRange[0] <= toCheckCaliber && toCheckCaliber <= caliberRange[1]) return 2;
            else return 0;
        }

        /// <summary>
        /// Check the main gun caliber and return the range it belongs to as an array of 2 integers [min, max].
        /// the max rang is inclusive.
        /// </summary>
        /// <returns>
        /// retur nan array of 2 integers [min, max] representing the range the caliber belongs to.
        /// </returns>
        private int[] GetCaliberRange()
        {
            switch (((int)this.MainGunCaliber))
            {
                case <= 35: return new int[] { 0, 35 };
                case > 35 and <= 100: return new int[] { 36, 100 };
                case > 100: return new int[] { 101, 800 };// 800 is just a placeholder for "infinity"
            }
        }

        //will need some updates later 
        public override bool Equals(Object other) => this.VehicleName == ((Vehicle)other).VehicleName;
        public override int GetHashCode() { return this.VehicleId.GetHashCode() + this.VehicleName.GetHashCode(); }

    }
}
