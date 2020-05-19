using System.Collections.Generic;

namespace Domain
{
    public class ContractedCars
    {
        public readonly ICollection<ContractCar> ConfirmedRents;
        public readonly ICollection<string> NotFoundCars;
        public readonly int TotalCost;
        public readonly int TotalBonus;

        public ContractedCars(
            ICollection<ContractCar> confirmedRents,
            ICollection<string> notFoundCars,
            int totalCost, 
            int totalBonus
            )
        {
            ConfirmedRents = confirmedRents;
            NotFoundCars = notFoundCars;
            TotalCost = totalCost;
            TotalBonus = totalBonus;
        }
    }
}
