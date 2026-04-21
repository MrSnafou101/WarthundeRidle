using Warthuneridle.Models.DicoKeys;

namespace Warthuneridle.Models
{
    public abstract class Vehicle: ICloneable
    {
        public int VehicleId { get; set; }//may change to UUID later
        public string VehicleName { get; set; } = "vehicle name";
        public string? PictureURL { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public Nation Country { get; set; } = new Nation();
        public VehicleRank Rank { get; set; } = new VehicleRank();
        public TechTreePositions TechTreePosition { get; set; }
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

        //will need some tweeking later 
        public override bool Equals(Object other) => this.VehicleName == ((Vehicle)other).VehicleName;
        public override int GetHashCode() { return this.VehicleName.GetHashCode(); }

    }
}
