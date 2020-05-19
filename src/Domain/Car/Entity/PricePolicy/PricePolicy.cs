using System;
using System.Collections.Generic;

namespace Domain
{
    public class PricePolicy : IEquatable<PricePolicy>
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public IEnumerable<RentType> RentTypes { get; set; }

        private PricePolicy()
        {
        }

        public PricePolicy(string name, int price)
        {
            Name = name;
            Price = price;
            RentTypes = new List<RentType>();
        }

        public PricePolicy(string name, int price, IEnumerable<RentType> rentTypes)
        {
            Name = name;
            Price = price;
            RentTypes = rentTypes;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Price)}: {Price}, {nameof(RentTypes)}: {RentTypes}";
        }

        public bool Equals(PricePolicy other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Price == other.Price && Equals(RentTypes, other.RentTypes);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PricePolicy) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price, RentTypes);
        }

        public static bool operator ==(PricePolicy left, PricePolicy right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PricePolicy left, PricePolicy right)
        {
            return !Equals(left, right);
        }
    }
}