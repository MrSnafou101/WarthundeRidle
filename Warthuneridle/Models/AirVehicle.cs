using Warthuneridle.Models.DicoKeys;

namespace Warthuneridle.Models
{
    public class AirVehicle : Vehicle
    {
        public aircraftEngineType EngineType { get; set; }
        public int MaxAltitude { get; set; } = 0;
        public bool CanGoMach1 { get; set; } = false;
        public int MaxSpeed { get; set; }
        public bool CanCarryGroundOrdnance { get; set; } = true;

        public AirVehicle() { }
        public AirVehicle(int id, string name, Nation country, VehicleRank rank, VehicleTypes vehicleType, TechTreePositions techTreePosition,
            double mainGunCaliber, aircraftEngineType engineType, int maxAltitude, bool canGoMach1, int maxSpeed, bool canCarryGroundOrdnance)
        {
            VehicleId = id;
            VehicleName = name;
            Country = country;
            Rank = rank;
            VehicleType = vehicleType;
            TechTreePosition = techTreePosition;
            MainGunCaliber = mainGunCaliber;
            EngineType = engineType;
            MaxAltitude = maxAltitude;
            CanGoMach1 = canGoMach1;
            MaxSpeed = maxSpeed;
            CanCarryGroundOrdnance = canCarryGroundOrdnance;
        }

        public override object Clone()
        {
            return new AirVehicle(
                this.VehicleId,
                this.VehicleName,
                (Nation)this.Country.Clone(),
                (VehicleRank)this.Rank.Clone(),
                this.VehicleType,
                this.TechTreePosition,
                this.MainGunCaliber,
                this.EngineType,
                this.MaxAltitude,
                this.CanGoMach1,
                this.MaxSpeed,
                this.CanCarryGroundOrdnance
            );
        }

        public override Dictionary<VehicleStatsKeys, int> CompareVehicles(Vehicle target)
        {
            this.ComparisonResults = new Dictionary<VehicleStatsKeys, int>() {
                {VehicleStatsKeys.name,-1 },
                {VehicleStatsKeys.nations,-1 },
                {VehicleStatsKeys.guncaliber,-1 },
                {VehicleStatsKeys.rank,-1 },
                {VehicleStatsKeys.type,-1 },
                {VehicleStatsKeys.position,-1 },
                {VehicleStatsKeys.enginetype, -1 },
                {VehicleStatsKeys.maxaltitude, -1 },
                {VehicleStatsKeys.cangomach1, -1 },
                {VehicleStatsKeys.maxspeed, -1 },
                {VehicleStatsKeys.cancarrygroundordnance, -1 }
            };

            if (target is AirVehicle av)
            {
                target = (AirVehicle)target;
                this.ComparisonResults[VehicleStatsKeys.name] = this.VehicleName == av.VehicleName ? 1 : 0;
                this.ComparisonResults[VehicleStatsKeys.nations] = this.Country.IsCorrectNation(av.Country);
                this.ComparisonResults[VehicleStatsKeys.guncaliber] = IsSameCaliber((int)av.MainGunCaliber);
                this.ComparisonResults[VehicleStatsKeys.rank] = this.Rank.IsSameRankAndBR(av.Rank);
                this.ComparisonResults[VehicleStatsKeys.type] = isSameVehicleType(av.VehicleType);
                this.ComparisonResults[VehicleStatsKeys.position] = IsSameTechTreePosition(av.TechTreePosition);
                this.ComparisonResults[VehicleStatsKeys.enginetype] = this.EngineType == av.EngineType ? 1 : 0;
                this.ComparisonResults[VehicleStatsKeys.maxaltitude] = IsSameMaxAltitude(av.MaxAltitude);
                this.ComparisonResults[VehicleStatsKeys.cangomach1] = this.CanGoMach1 == av.CanGoMach1 ? 1 : 0;
                this.ComparisonResults[VehicleStatsKeys.maxspeed] = IsSameMaxSpeed(av.MaxSpeed);
                this.ComparisonResults[VehicleStatsKeys.cancarrygroundordnance] = this.CanCarryGroundOrdnance == av.CanCarryGroundOrdnance ? 1 : 0;

            }
            return this.ComparisonResults;
        }

        private int IsSameMaxSpeed(int maxSpeed)
        {
            if(this.MaxSpeed == maxSpeed)return 1;
            else if (Math.Abs(this.MaxSpeed - maxSpeed) <= 100) return 2; //May change to 50km/h later depending on the results
            else return 0;
        }

        private int IsSameMaxAltitude(int toCheckMaxAltitude){
            if (this.MaxAltitude == toCheckMaxAltitude) return 1;
            else if (Math.Abs(this.MaxAltitude - toCheckMaxAltitude) <= 1000) return 2; //May change to 500m later depending on the results
            else return 0;
        }

        public override bool Equals(Object other) => this.VehicleName == ((AirVehicle)other).VehicleName;
        public override int GetHashCode()
        {
            return this.VehicleName.GetHashCode();

            //public override bool Equals(Object other) => this.VehicleId == ((AirVehicle)other).VehicleId;
            //public override int GetHashCode(){ return this.VehicleId.GetHashCode(); }

        }

    }
}
