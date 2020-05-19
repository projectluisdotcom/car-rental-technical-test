using System;

namespace Domain
{
    public class ReturnedCar : IEquatable<ReturnedCar>
    {
        public readonly string License;
        public readonly string Model;
        public readonly string Brand;
        public readonly int ContractedDays;
        public readonly int OvertimeDays;
        public readonly int ContractedPrice;
        public readonly int TotalPayed;
        public readonly int BonusWon;

        public ReturnedCar(string license, string model, string brand, int contractedDays, int overtimeDays, int contractedPrice, int totalPayed, int bonusWon)
        {
            License = license;
            Model = model;
            Brand = brand;
            ContractedDays = contractedDays;
            OvertimeDays = overtimeDays;
            ContractedPrice = contractedPrice;
            TotalPayed = totalPayed;
            BonusWon = bonusWon;
        }

        public bool Equals(ReturnedCar other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return License == other.License && Model == other.Model && Brand == other.Brand && ContractedDays == other.ContractedDays && OvertimeDays == other.OvertimeDays && ContractedPrice == other.ContractedPrice && TotalPayed == other.TotalPayed && BonusWon == other.BonusWon;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ReturnedCar) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(License, Model, Brand, ContractedDays, OvertimeDays, ContractedPrice, TotalPayed, BonusWon);
        }

        public static bool operator ==(ReturnedCar left, ReturnedCar right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ReturnedCar left, ReturnedCar right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{nameof(License)}: {License}, {nameof(Model)}: {Model}, {nameof(Brand)}: {Brand}, {nameof(ContractedDays)}: {ContractedDays}, {nameof(OvertimeDays)}: {OvertimeDays}, {nameof(ContractedPrice)}: {ContractedPrice}, {nameof(TotalPayed)}: {TotalPayed}, {nameof(BonusWon)}: {BonusWon}";
        }
    }
}