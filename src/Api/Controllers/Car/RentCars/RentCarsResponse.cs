using System.Collections.Generic;

namespace Api
{
    public class RentCarsResponse
    {
        public List<RentContract> Contracts { get; private set; } 
        public int TotalPrice { get; private set; }
        public int TotalBonus { get; private set; }
        public ICollection<string> NotFoundCars { get; private set; } 


        public RentCarsResponse(List<RentContract> contracts, int totalPrice, int totalBonus, ICollection<string> notFoundCars)
        {
            Contracts = contracts;
            TotalPrice = totalPrice;
            TotalBonus = totalBonus;
            NotFoundCars = notFoundCars;
        }
    }
}