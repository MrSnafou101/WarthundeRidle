using Warthuneridle.Models;
using Warthuneridle.Models.DicoKeys;


public sealed class NullGroundVehicle : Vehicle //GroundVehicle
{
    public static readonly NullGroundVehicle Instance = new NullGroundVehicle();
    private NullGroundVehicle()
    {
        VehicleId = -1;
        VehicleName = "Null Ground Vehicle";
        VehicleType = VehicleTypes.NULL;
        Country = new Nation();
        Rank = new VehicleRank();
        TechTreePosition = TechTreePositions.Null;
        MainGunCaliber = 0.0;
        //HasMultipleMainGuns = 0;
        //HasAuxiliaryWeapons = false;
        //HasTracks = false;
        //WeightInTons = 0.0;
    }

    public override object Clone()
    {
        return this;
    }

    public override Dictionary<VehicleStatsKeys, int> CompareVehicles(Vehicle target)
    {
        ComparisonResults = new Dictionary<VehicleStatsKeys, int>();
        foreach (VehicleStatsKeys key in Enum.GetValues(typeof(VehicleStatsKeys)))
        {
            this.ComparisonResults.Add(key, -1);
        }
        return ComparisonResults;
    }
}
