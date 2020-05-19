using System;
using Domain.Common;

namespace Domain
{
    public class Car : IAggregateRoot, IEquatable<Car>
    {
        public string License { get; private set; }
        public bool IsFree { get; private set; }
        public CarModel Model { get; private set; }
        
        private Car()
        {
        }

        public Car(string license, CarModel model)
        {
            License = license;
            Model = model;
            IsFree = true;
        }

        public Car(string license, bool isFree, CarModel model)
        {
            License = license;
            IsFree = isFree;
            Model = model;
        }

        public void Free()
        {
            IsFree = true;
        }
        
        public void Rent()
        {
            IsFree = false;
        }

        public override string ToString()
        {
            return $"{nameof(License)}: {License}, {nameof(IsFree)}: {IsFree}, {nameof(Model)}: {Model}";
        }

        public bool Equals(Car other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return License == other.License && IsFree == other.IsFree && Equals(Model, other.Model);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Car) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(License, IsFree, Model);
        }

        public static bool operator ==(Car left, Car right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Car left, Car right)
        {
            return !Equals(left, right);
        }
    }
}