using System;
using System.Security.Claims;
using Warthuneridle.Models;


public class NullGroundVehicle
{
    public int VehicleId { get; set; }
    public string VehicleName { get; set; }
    public string PictureURL { get; set; }
    public VehicleTypes VehicleType { get; set; }
    public Nation Country { get; set; }
    public int MainGunCaliber { get; set; }
    public int HasMultipleMainGuns { get; set; }
    public bool HasAuxiliaryWeapons { get; set; }
    public bool HasTracks { get; set; }
    public double WeightInTons { get; set; }
    public VehicleRank Rank { get; set; }
    public TechTreePositions TechTreePosition { get; set; }

    public Dictionary<string, int> CompareVehicles(GroundVehicle target) {
        Dictionary<string, int> resDico = new Dictionary<string, int>() {
            {"name",-1 },                                    
            {"nations",-1 },                                    
            {"gunCaliber",-1 },                                    
            {"gunAmount",-1 },                                    
            {"auxiliaryGun",-1 },                                    
            {"rank",-1 },                                    
            {"type",-1 },                                    
            {"position",-1 },                                    
            {"weight",-1 },                                    
            {"tracks",-1 }                                    
        };

        return resDico;
    }

    public override bool Equals(Object other) => this.VehicleId == ((GroundVehicle)other).VehicleId;
    public override int GetHashCode(){ return this.VehicleId.GetHashCode(); }
}
