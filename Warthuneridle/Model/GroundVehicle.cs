using System;
using Warthuneridle.Model;


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


}
