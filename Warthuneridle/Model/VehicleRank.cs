public class VehicleRank
{
    public int RankValue { get; set; }
    public double BattleRating { get; set; }

    public string getRankString()
    {
        return $"Rank {RankValue} : BR {BattleRating}";
    }
    public int IsSameRankAndBR(VehicleRank rankToCompare)
    {
        if (this.RankValue == rankToCompare.RankValue && this.BattleRating == rankToCompare.BattleRating)
        {
            return 1;
        }
        else if (this.RankValue == rankToCompare.RankValue && this.BattleRating != rankToCompare.BattleRating)
        {
            return 2;
        }
        else if (this.RankValue != rankToCompare.RankValue && this.BattleRating == rankToCompare.BattleRating)
        {
            return 3;
        }
        else { return 0; }
    }
}