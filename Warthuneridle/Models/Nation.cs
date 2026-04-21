using Warthuneridle.Models;

public class Nation{
    public string NationName { get; set; } = "nation name";
    public string? FlagURL { get; set; }
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