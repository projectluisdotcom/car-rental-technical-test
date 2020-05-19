using System.Collections.Generic;

namespace Domain
{
    public class ReturnSummary
    {
        public IEnumerable<ReturnedCar> ReturnedCars { get; private set; }
        public int TotalPriceContracted { get; private set; }
        public int TotalPayed { get; private set; }
        public int TotalBonus { get; private set; }

        public ReturnSummary(IEnumerable<ReturnedCar> returnedCars, int totalPriceContracted, int totalPayed, int totalBonus)
        {
            ReturnedCars = returnedCars;
            TotalPriceContracted = totalPriceContracted;
            TotalPayed = totalPayed;
            TotalBonus = totalBonus;
        }
    }
}