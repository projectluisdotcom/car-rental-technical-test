using System;

namespace Domain
{
    public class ContractCar : IEquatable<ContractCar>
    {
        public readonly string License;
        public readonly string Model;
        public readonly string Brand;
        public readonly int ContractedDays;
        public readonly int ContractedPrice;
        public readonly int BonusWon;

        public ContractCar(string license, string model, string brand, int contractedDays, int contractedPrice, int bonusWon)
        {
            License = license;
            Model = model;
            Brand = brand;
            ContractedDays = contractedDays;
            ContractedPrice = contractedPrice;
            BonusWon = bonusWon;
        }
        public bool Equals(ContractCar other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return License == other.License && Model == other.Model && Brand == other.Brand && ContractedDays == other.ContractedDays && ContractedPrice == other.ContractedPrice && BonusWon == other.BonusWon;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ContractCar) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(License, Model, Brand, ContractedDays, ContractedPrice, BonusWon);
        }

        public static bool operator ==(ContractCar left, ContractCar right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ContractCar left, ContractCar right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{nameof(License)}: {License}, {nameof(Model)}: {Model}, {nameof(Brand)}: {Brand}, {nameof(ContractedDays)}: {ContractedDays}, {nameof(ContractedPrice)}: {ContractedPrice}, {nameof(BonusWon)}: {BonusWon}";
        }
    }
}
