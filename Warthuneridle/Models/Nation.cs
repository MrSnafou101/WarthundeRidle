using System.ComponentModel.DataAnnotations;
using Warthuneridle.Models;

public class Nation{
    [Display(Name = "Nation Name", GroupName ="Nation")]
    public string NationName { get; set; } = "nation name";

    [Display(Name = "Nation Flag", GroupName = "Nation")]
    public string? FlagURL { get; set; }

    [Display(Name = "Continent", GroupName = "Nation")]
    public Continents Continent { get; set; } = Continents.Unknown;

    public int IsCorrectNation(Nation nationToCompare){
        if (this.NationName == nationToCompare.NationName){
            return 1;
        }else if (this.NationName != nationToCompare.NationName && this.Continent == nationToCompare.Continent){
            return 2;
        }else { return 0; }
    }
    public Object Clone(){
        return new Nation{
            NationName = this.NationName,
            FlagURL = this.FlagURL,
            Continent = this.Continent
        };
    }

    public override string ToString(){
        return $"{NationName} ({Continent})";
    }
}