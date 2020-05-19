using System;
using System.Collections.Generic;

namespace Domain
{
    public class RentType : IEquatable<RentType>
    {
        public string Name { get; private set; }
        public int BonusOnRent { get; private set; }
        public PricePolicy PricePolicy { get; private set; }
        public TimeSpan DiscountAfter { get; private set; }
        public decimal Discount { get; private set; }
        public IEnumerable<CarModel> CarModels { get; set; }

        private RentType()
        {
        }
        
        public RentType(string name, int bonusOnRent, PricePolicy pricePolicy)    
        {
            Name = name;
            BonusOnRent = bonusOnRent;
            PricePolicy = pricePolicy;
            DiscountAfter = TimeSpan.Zero;
            Discount = 0;
            CarModels = new List<CarModel>();
        }

        public RentType(string name, int bonusOnRent, PricePolicy pricePolicy, TimeSpan discountAfter, decimal discount)    
        {
            Name = name;
            BonusOnRent = bonusOnRent;
            PricePolicy = pricePolicy;
            DiscountAfter = discountAfter;
            Discount = discount;
            CarModels = new List<CarModel>();
        }

        public RentType(string name, int bonusOnRent, PricePolicy pricePolicy, TimeSpan discountAfter, decimal discount, IEnumerable<CarModel> carModels)
        {
            Name = name;
            BonusOnRent = bonusOnRent;
            PricePolicy = pricePolicy;
            DiscountAfter = discountAfter;
            Discount = discount;
            CarModels = carModels;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(BonusOnRent)}: {BonusOnRent}, {nameof(PricePolicy)}: {PricePolicy}, {nameof(DiscountAfter)}: {DiscountAfter}, {nameof(Discount)}: {Discount}, {nameof(CarModels)}: {CarModels}";
        }

        public bool Equals(RentType other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && BonusOnRent == other.BonusOnRent && Equals(PricePolicy, other.PricePolicy) && DiscountAfter.Equals(other.DiscountAfter) && Discount == other.Discount && Equals(CarModels, other.CarModels);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RentType) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, BonusOnRent, PricePolicy, DiscountAfter, Discount, CarModels);
        }

        public static bool operator ==(RentType left, RentType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RentType left, RentType right)
        {
            return !Equals(left, right);
        }
    }
}