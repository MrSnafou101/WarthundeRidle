using System.ComponentModel.DataAnnotations;
using Warthuneridle.Models;
using Warthuneridle.Models.DicoKeys;


public class GroundVehicle : Vehicle
{
    /*** Vehicle caracteristics ***/
    /*
     int instead of boolean the amount of guns will be a hint like so:
        0 = no main gun (ATGM carrier, SAM AA)
        1 = one main gun
        2 = 2 or more main guns
     */
    [Display(Name = "Number of main guns 0,1 or 2+")]
    [AllowedValues(0, 1, 2, ErrorMessage = "The number of main guns should be 0, 1 or 2+")]
    public int HasMultipleMainGuns { get; set; }

    [Display(Name = "Have auxiliary weapons (MG excluded)")]
    public bool HasAuxiliaryWeapons { get; set; }

    [Display(Name = "Use tracks")]
    public bool HasTracks { get; set; }

    [Display(Name = "Weight (tons)")]
    [Range(0, 500, ErrorMessage = "The weights must be between 0 and 500 tons")]
    public double WeightInTons { get; set; }

    public GroundVehicle() { }
    public GroundVehicle(int id, string name, Nation country, VehicleRank rank, VehicleTypes vehicleType, TechTreePositions techTreePosition, 
        double mainGunCaliber, int hasMultipleMainGuns, bool hasAuxiliaryWeapons, bool hasTracks, double weightInTons){
        VehicleId = id;
        VehicleName = name;
        Country = country;
        Rank = rank;
        VehicleType = vehicleType;
        TechTreePosition = techTreePosition;
        MainGunCaliber = mainGunCaliber;
        HasMultipleMainGuns = hasMultipleMainGuns;
        HasAuxiliaryWeapons = hasAuxiliaryWeapons;
        HasTracks = hasTracks;
        WeightInTons = weightInTons;
    }

    public override object Clone()
    {
        return new GroundVehicle(
            this.VehicleId, 
            this.VehicleName, 
            (Nation)this.Country.Clone(), 
            (VehicleRank)this.Rank.Clone(),
            this.VehicleType, 
            this.TechTreePosition,
            this.MainGunCaliber, 
            this.HasMultipleMainGuns, 
            this.HasAuxiliaryWeapons, 
            this.HasTracks, 
            this.WeightInTons
        );
    }

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
    public override Dictionary<VehicleStatsKeys, int> CompareVehicles(Vehicle target) {
        this.ComparisonResults = new Dictionary<VehicleStatsKeys, int>() {
            {VehicleStatsKeys.name,-1 },                                    
            {VehicleStatsKeys.nations,-1 },                                    
            {VehicleStatsKeys.guncaliber,-1 },
            {VehicleStatsKeys.rank,-1 },
            {VehicleStatsKeys.type,-1 },
            {VehicleStatsKeys.position,-1 },
            {VehicleStatsKeys.gunamount,-1 },                                    
            {VehicleStatsKeys.auxiliarygun,-1 },                                           
            {VehicleStatsKeys.weight,-1 },                                    
            {VehicleStatsKeys.tracks,-1 }                                    
        };
        //if (target.GetType().IsEquivalentTo(typeof(GroundVehicle)))
        if (target is GroundVehicle gv){
            target = (GroundVehicle)target;

            this.ComparisonResults[VehicleStatsKeys.name] = this.VehicleName == gv.VehicleName ? 1 : 0;
            this.ComparisonResults[VehicleStatsKeys.nations] = this.Country.IsCorrectNation(gv.Country);
            this.ComparisonResults[VehicleStatsKeys.guncaliber] = IsSameCaliber((int)gv.MainGunCaliber);
            this.ComparisonResults[VehicleStatsKeys.rank] = this.Rank.IsSameRankAndBR(gv.Rank);
            this.ComparisonResults[VehicleStatsKeys.type] = isSameVehicleType(gv.VehicleType);
            this.ComparisonResults[VehicleStatsKeys.position] = IsSameTechTreePosition(gv.TechTreePosition);
            this.ComparisonResults[VehicleStatsKeys.gunamount] = HasSameGunNumbers(gv.HasMultipleMainGuns) ? 1 : 0;
            this.ComparisonResults[VehicleStatsKeys.auxiliarygun] = this.HasAuxiliaryWeapons == gv.HasAuxiliaryWeapons ? 1 : 0;
            this.ComparisonResults[VehicleStatsKeys.weight] = IsSameWeight(gv.WeightInTons);
            this.ComparisonResults[VehicleStatsKeys.tracks] = this.HasTracks == gv.HasTracks ? 1 : 0;
        }

        return this.ComparisonResults;
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

    public bool HasSameGunNumbers(int gunNumberToCheck) => this.HasMultipleMainGuns == gunNumberToCheck;


    public override bool Equals(Object other) => this.VehicleName == ((GroundVehicle)other).VehicleName;
    public override int GetHashCode()
    {
        return this.VehicleName.GetHashCode();

        //public override bool Equals(Object other) => this.VehicleId == ((GroundVehicle)other).VehicleId;
        //public override int GetHashCode(){ return this.VehicleId.GetHashCode(); }

    }
}
