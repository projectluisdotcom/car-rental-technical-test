using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api
{
    [ApiController]
    public class ReturnCarsController : ControllerBase
    {
        private readonly IReturnCars _returnCars;

        public ReturnCarsController(IReturnCars returnCars)
        {
            _returnCars = returnCars;
        }
        
        [HttpPost]
        [Route("api/car/return")]
        [ProducesResponseType(typeof(ReturnCarsResponse), (int)HttpStatusCode.OK)]
        public async Task<ReturnCarsResponse> Post([FromBody] ReturnCarsRequest request)
        {
            var now = DateTime.Now;
            var returnedCards = new ReturnRequest(request.UserName, request.LicenseNumbers, now);
            var confirmation = await _returnCars.Return(returnedCards);
            var confirmedReturnedCars = confirmation.ReturnedCars.Select(returned => 
                new ReturnedCar(
                    returned.License,
                    returned.Model,
                    returned.OvertimeDays,
                    returned.TotalPayed,
                    returned.ContractedPrice,
                    returned.BonusWon
                )
            ).ToList();
            
            return new ReturnCarsResponse(
                confirmedReturnedCars,
                confirmation.TotalPriceContracted,
                confirmation.TotalPayed,
                confirmation.TotalBonus
            );
        }
    }
}