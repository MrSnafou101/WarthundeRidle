public class VehicleRank{
    public int RankValue { get; set; } = -1;
    public double BattleRating { get; set; } = -1.0;

    public string getRankString(){
        return $"Rank {RankValue} : BR {BattleRating}";
    }
    public int IsSameRankAndBR(VehicleRank rankToCompare){
        if (this.RankValue == rankToCompare.RankValue && this.BattleRating == rankToCompare.BattleRating){
            return 1;
        }else if (this.RankValue == rankToCompare.RankValue && this.BattleRating != rankToCompare.BattleRating){
            return 2;
        }else if (this.RankValue != rankToCompare.RankValue && this.BattleRating == rankToCompare.BattleRating){
            return 3;
        }else { return 0; }
    }
    
    public Object Clone(){
        return new VehicleRank{
            RankValue = this.RankValue,
            BattleRating = this.BattleRating
        };
    }

    public override string ToString(){
        return $"Rank {RankValue} : BR {BattleRating}";
    }
}