using System.Collections.Generic;

namespace Api
{
    public class ReturnCarsResponse
    {
        public List<ReturnedCar> ReturnedCars { get; private set; }
        public int TotalPriceContracted { get; private set; }
        public int TotalPayed { get; private set; }
        public int TotalBonus { get; private set; }
        
        private ReturnCarsResponse()
        {
        }

        public ReturnCarsResponse(List<ReturnedCar> returnedCars, int totalPriceContracted, int totalPayed, int totalBonus)
        {
            ReturnedCars = returnedCars;
            TotalPriceContracted = totalPriceContracted;
            TotalPayed = totalPayed;
            TotalBonus = totalBonus;
        }
    }
}