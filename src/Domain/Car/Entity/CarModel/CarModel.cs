using System;
using System.Collections.Generic;

namespace Domain
{
    public class CarModel : IEquatable<CarModel>
    {
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public RentType RentType { get; private set; }
        public IEnumerable<Car> Car { get; set; }

        private CarModel()
        {
        }

        public CarModel(string name, string brand, RentType rentType)
        {
            Name = name;
            Brand = brand;
            RentType = rentType;
            Car = new List<Car>();
        }

        public CarModel(string name, string brand, RentType rentType, IEnumerable<Car> car)
        {
            Name = name;
            Brand = brand;
            RentType = rentType;
            Car = car;
        }

        public override string ToString()
        {
            return $"{nameof(Brand)}: {Brand}, {nameof(Name)}: {Name}, {nameof(RentType)}: {RentType}, {nameof(Car)}: {Car}";
        }

        public bool Equals(CarModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Brand == other.Brand && Name == other.Name && Equals(RentType, other.RentType) && Equals(Car, other.Car);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CarModel) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Brand, Name, RentType, Car);
        }

        public static bool operator ==(CarModel left, CarModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CarModel left, CarModel right)
        {
            return !Equals(left, right);
        }
    }
}