using System.Collections.Generic;

namespace Domain
{
    public class AvailableCars
    {
        public readonly IEnumerable<Car> Cars;

        public AvailableCars(IEnumerable<Car> cars)
        {
            Cars = cars;
        }
    }
}