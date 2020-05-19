using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api
{
    public class RentCarsRequest
    {
        [Required(ErrorMessage = "Please provide your userName")]
        public string UserName { get; private set; }
        
        [Required(ErrorMessage = "Please provide car models to rent")]
        public List<RentRequest> RentRequests { get; private set; }

        private RentCarsRequest()
        {
        }

        public RentCarsRequest(string userName, List<RentRequest> rentRequests)
        {
            UserName = userName;
            RentRequests = rentRequests;
        }
    }
}