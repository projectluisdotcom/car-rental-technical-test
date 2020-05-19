using System.Collections.Generic;

namespace Api
{
    public class GetCarsResponse
    {
        public List<AvailableCar> AvailableCars { get; private set; }

        private GetCarsResponse()
        {
        }

        public GetCarsResponse(List<AvailableCar> availableCars)
        {
            AvailableCars = availableCars;
        }
    }
}