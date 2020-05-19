using System;

namespace Domain
{
    public class CarRent : IEquatable<CarRent>
    {
        public string CarId { get; private set; }
        
        public DateTime Started { get; private set; }
        
        public DateTime ContractedEnd { get; private set; }
        
        public int ContractedPrice { get; private set; }
        public int BonusWon { get; private set; }
        
        public DateTime End { get; private set; }
        
        public int PricePayed { get; private set; }

        public CarRentStatus Status { get; private set; }

        private CarRent()
        {
        }
        
        public CarRent(string carId, DateTime started, int contractedPrice, int bonusWon, int daysContracted)
        {
            CarId = carId;
            ContractedEnd = started.AddDays(daysContracted);
            Started = started;
            ContractedPrice = contractedPrice;
            Status = CarRentStatus.Pending;
            BonusWon = bonusWon;
            End = started;
            PricePayed = 0;
        }

            public CarRent(string carId, DateTime started, DateTime contractedEnd, int contractedPrice, int bonusWon, DateTime end, int pricePayed, CarRentStatus status)
        {
            CarId = carId;
            Started = started;
            ContractedEnd = contractedEnd;
            ContractedPrice = contractedPrice;
            BonusWon = bonusWon;
            End = end;
            PricePayed = pricePayed;
            Status = status;
        }
        public int GetContractedDays()
        {
            return (ContractedEnd - Started).Days;
        }

        public int GetOvertimeDays()
        {
            if (Status == CarRentStatus.Pending)
            {
                return 0;
            }
            return (End - Started).Days - GetContractedDays();
        }
        
        public void Returned(int pricePayed, DateTime now)
        {
            PricePayed = pricePayed;
            Status = CarRentStatus.Payed;
            End = now;
        }

        public bool Equals(CarRent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CarId == other.CarId && Started.Equals(other.Started) && ContractedEnd.Equals(other.ContractedEnd) && ContractedPrice == other.ContractedPrice && BonusWon == other.BonusWon && End.Equals(other.End) && PricePayed == other.PricePayed && Status == other.Status;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CarRent) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CarId, Started, ContractedEnd, ContractedPrice, BonusWon, End, PricePayed, (int) Status);
        }

        public static bool operator ==(CarRent left, CarRent right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CarRent left, CarRent right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{nameof(CarId)}: {CarId}, {nameof(Started)}: {Started}, {nameof(ContractedEnd)}: {ContractedEnd}, {nameof(ContractedPrice)}: {ContractedPrice}, {nameof(BonusWon)}: {BonusWon}, {nameof(End)}: {End}, {nameof(PricePayed)}: {PricePayed}, {nameof(Status)}: {Status}";
        }

        public TimeSpan CalculateTotalTime(DateTime now)
        {
            return now - Started;
        }
    }
}