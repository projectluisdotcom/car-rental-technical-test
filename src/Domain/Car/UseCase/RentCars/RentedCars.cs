using System;
using System.Collections.Generic;

namespace Domain
{
    public class RentedCars
    {
        public readonly string UserName;
        public readonly IEnumerable<RentRequest> RentRequests;
        public readonly DateTime Now;

        public RentedCars(string userName, IEnumerable<RentRequest> rentRequests, DateTime now)
        {
            UserName = userName;
            RentRequests = rentRequests;
            Now = now;
        }
    }
}
