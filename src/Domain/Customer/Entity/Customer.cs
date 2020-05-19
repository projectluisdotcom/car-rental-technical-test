using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain
{
    public class Customer : IAggregateRoot, IEquatable<Customer>
    {
        public string Name { get; private set; }
        public List<CarRent> CarRents { get; private set; }
        
        private Customer()
        {
        }
         
        public Customer(string name)
        {
            Name = name;
            CarRents = new List<CarRent>();
        }

        public Customer(string name, List<CarRent> carRents)
        {
            Name = name;
            CarRents = carRents;
        }

        public bool Equals(Customer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Customer) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public static bool operator ==(Customer left, Customer right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Customer left, Customer right)
        {
            return !Equals(left, right);
        }
    }
}