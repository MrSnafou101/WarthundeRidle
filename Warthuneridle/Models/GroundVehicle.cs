using System;
using System.Security.Claims;
using Warthuneridle.Models;


public class GroundVehicle
{
    /*** Vehicle identification properties ***/
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
    /*** Vahicle's in game properties ***/
    public VehicleRank Rank { get; set; }
    public TechTreePositions TechTreePosition { get; set; }

    public int[] CompareVehicles(GroundVehicle target) {
        int[] resTab = new int[]{ -1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
        int index = 0;

        foreach (var prop in this.GetType().GetProperties()) {
        
        }

        return null;
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
    private int[] GetCaliberRange(){
        switch (this.MainGunCaliber){
            case <= 35: return new int[]{0,35};
            case > 35 and <=100: return new int[]{36,100};
            case > 100: return new int[] { 101, -5};// -5 is just a placeholder for "infinity" since we can't use it in a range check
        }
    }
    
    public override bool Equals(Object other) => this.VehicleName == ((GroundVehicle)other).VehicleName;
    public override int GetHashCode()
    {
        return VehicleName.GetHashCode();
    }
}
