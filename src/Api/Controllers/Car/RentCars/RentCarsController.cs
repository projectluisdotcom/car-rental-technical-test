using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api
{
    [ApiController]
    public class RentCarsRestController : ControllerBase
    {
        private readonly IRentCars _rentCars;

        public RentCarsRestController(IRentCars rentCars)
        {
            _rentCars = rentCars;
        }

        [HttpPost]
        [Route("api/car/rent")]
        [ProducesResponseType(typeof(RentCarsResponse), (int)HttpStatusCode.OK)]
        public async Task<RentCarsResponse> Post([FromBody] RentCarsRequest request)
        {
            var rentedCars = request.RentRequests.Select(detail => new Domain.RentRequest(detail.Model, detail.Days));
            var now = DateTime.Now;
            var mappedRequest = new RentedCars(request.UserName, rentedCars, now);
            var rented = await _rentCars.Rent(mappedRequest);
            var contracts = rented.ConfirmedRents.Select(rent => 
                new RentContract(
                    rent.License, 
                    rent.Model, 
                    rent.ContractedPrice, 
                    rent.BonusWon
            ));
            
            return new RentCarsResponse(contracts.ToList(), rented.TotalCost, rented.TotalBonus, rented.NotFoundCars);
        }
    }
}