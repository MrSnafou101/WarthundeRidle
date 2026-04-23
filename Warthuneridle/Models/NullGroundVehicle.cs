using System;
using System.Security.Claims;
using Warthuneridle.Models;
using Warthuneridle.Models.DicoKeys;


public sealed class NullGroundVehicle : Vehicle
{
    public static readonly NullGroundVehicle Instance = new NullGroundVehicle();
    private NullGroundVehicle()
    {
        VehicleId = -1;
        VehicleName = "Null Ground Vehicle";
        VehicleType = VehicleTypes.Null;
        Country = new Nation();
        Rank = new VehicleRank();
        TechTreePosition = TechTreePositions.Null;
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
