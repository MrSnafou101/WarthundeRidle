using System;
using System.Security.Claims;
using Warthuneridle.Models;
using Warthuneridle.Models.DicoKeys;


public class GroundVehicle
{
    /*** Vehicle identification properties ***/
    public int VehicleId { get; set; }// may change to UUID
    public string VehicleName { get; set; }
    public string PictureURL { get; set; }
    public VehicleTypes VehicleType { get; set; }
    public Nation Country { get; set; }
    /*** Vehicle caracteristics ***/
    public int MainGunCaliber { get; set; }
    /*
     int instead of boolean the amount of guns will be a hint like so:
        0 = no main gun (ATGM carrier, SAM AA)
        1 = one main gun
        2 = more than 2 main guns
     */
    public int HasMultipleMainGuns { get; set; }
    public bool HasAuxiliaryWeapons { get; set; }
    public bool HasTracks { get; set; }
    public double WeightInTons { get; set; }
    /*** Vehicle's in game properties ***/
    public VehicleRank Rank { get; set; }
    public TechTreePositions TechTreePosition { get; set; }
    /*** working propeties ***/
    public Dictionary<GroundStatsKeys, int> ComparisonResults { get; set; }

    /*** Comparation methodes ***/
    /// <summary>
    /// Compare 2 ground vechile and return a dictionary with the results of the comparison for each property.
    /// </summary>
    /// <param name="target"> the vehicle to compare with</param>
    /// <returns>
    /// A dictionary that contains each property that was used in the comparaison as key
    /// and the value is he result :
    ///  0 => totaly different
    ///  1 => same
    ///  2 => partially similar (used for caliber and weight when they are not the same but within the same range)
    /// </returns>
    public Dictionary<GroundStatsKeys, int> CompareVehicles(GroundVehicle target) {
        this.ComparisonResults = new Dictionary<GroundStatsKeys, int>() {
            {GroundStatsKeys.name,-1 },                                    
            {GroundStatsKeys.nations,-1 },                                    
            {GroundStatsKeys.guncaliber,-1 },                                    
            {GroundStatsKeys.gunamount,-1 },                                    
            {GroundStatsKeys.auxiliarygun,-1 },                                    
            {GroundStatsKeys.rank,-1 },                                    
            {GroundStatsKeys.type,-1 },                                    
            {GroundStatsKeys.position,-1 },                                    
            {GroundStatsKeys.weight,-1 },                                    
            {GroundStatsKeys.tracks,-1 }                                    
        };

        this.ComparisonResults[GroundStatsKeys.name] = this.VehicleName == target.VehicleName ? 1 : 0;
        this.ComparisonResults[GroundStatsKeys.nations] = this.Country.IsCorrectNation(target.Country);
        this.ComparisonResults[GroundStatsKeys.guncaliber] = IsSameCaliber(target.MainGunCaliber);
        this.ComparisonResults[GroundStatsKeys.gunamount] = HasSameGunNumbers(target.HasMultipleMainGuns) ? 1 : 0;
        this.ComparisonResults[GroundStatsKeys.auxiliarygun] = this.HasAuxiliaryWeapons == target.HasAuxiliaryWeapons ? 1 : 0;
        this.ComparisonResults[GroundStatsKeys.rank] = this.Rank.IsSameRankAndBR(target.Rank);
        this.ComparisonResults[GroundStatsKeys.type] = isSameVehicleType(target.VehicleType);
        this.ComparisonResults[GroundStatsKeys.position] = IsSameTechTreePosition(target.TechTreePosition);
        this.ComparisonResults[GroundStatsKeys.weight] = IsSameWeight(target.WeightInTons);
        this.ComparisonResults[GroundStatsKeys.tracks] = this.HasTracks == target.HasTracks ? 1 : 0;

        return this.ComparisonResults;
    }
    public int GetstatComparaisonByStringKey(string key){
        if (Enum.TryParse(typeof(GroundStatsKeys), key, out var v)){
            if (this.ComparisonResults != null && this.ComparisonResults.TryGetValue((GroundStatsKeys)v, out var res)) return res;
            else return -1;
        }
        else {
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
    /// Check if the weights are the same. if not will check ifthe difference is within 5 tons.
    /// </summary>
    /// <param name="toCheckWeight"> the weight to compare to</param>
    /// <returns>
    /// return 1 if the weigths are the same, 
    /// return 2 if the difference is within 5 tons,
    /// return 0 if the difference is more than 5 tons
    /// </returns>
    public int IsSameWeight(double toCheckWeight){
        if (this.WeightInTons == toCheckWeight) return 1;
        else if (Math.Abs(this.WeightInTons - toCheckWeight) <= 5) return 2;
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
    public int IsSameCaliber(int toCheckCaliber){
        int[] caliberRange = GetCaliberRange();
        if (this.MainGunCaliber == toCheckCaliber) return 1;
        else if (caliberRange[0] <= toCheckCaliber && toCheckCaliber <= caliberRange[1]) return 2;
        else return 0;
    }

    public bool HasSameGunNumbers(int gunNumberToCheck) => this.HasMultipleMainGuns == gunNumberToCheck;

    /** Utility methodes **/

    /// <summary>
    /// Check the main gun caliber and return the range it belongs to as an array of 2 integers [min, max].
    /// the max rang is inclusive.
    /// </summary>
    /// <returns>
    /// retur nan array of 2 integers [min, max] representing the range the caliber belongs to.
    /// </returns>
    private int[] GetCaliberRange(){
        switch (this.MainGunCaliber){
            case <= 35: return new int[]{0,35};
            case > 35 and <=100: return new int[]{36,100};
            case > 100: return new int[] { 101, 500};// 500 is just a placeholder for "infinity" since we can't use it in a range check
        }
    }

    public override bool Equals(Object other) => this.VehicleName == ((GroundVehicle)other).VehicleName;
    public override int GetHashCode() { return this.VehicleName.GetHashCode(); }
    //public override bool Equals(Object other) => this.VehicleId == ((GroundVehicle)other).VehicleId;
    //public override int GetHashCode(){ return this.VehicleId.GetHashCode(); }
}
