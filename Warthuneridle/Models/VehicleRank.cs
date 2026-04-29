using System.ComponentModel.DataAnnotations;
using Warthuneridle.Utils;

public class VehicleRank{

    [Display(Name = "Rank", GroupName = "Ranking")]
    public int RankValue { get; set; } = -1;

    [Display(Name = "Battle Rating", GroupName = "Ranking")]
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
        return $"Rank {NumberParser.ToRomanNumeral(RankValue)} : BR {BattleRating}";
    }
}