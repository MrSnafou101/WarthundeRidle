using Warthuneridle.Model;

public class Nation
{
    public string NationName { get; set; }
    public string FlagURL { get; set; }
    public Continents Continent { get; set; }

    public int IsCorrectNation(Nation nationToCompare)
    {
        if (this.NationName == nationToCompare.NationName)
        {
            return 1;
        }
        else if (this.NationName != nationToCompare.NationName && this.Continent == nationToCompare.Continent)
        {
            return 2;
        }
        else { return 0; }
    }
}