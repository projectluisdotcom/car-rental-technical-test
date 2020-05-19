using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api
{
    [ApiController]
    public class FetchAvailableCarsController : ControllerBase
    {
        private readonly IFetchAvailableCars _fetchAvailableCars;

        public FetchAvailableCarsController(IFetchAvailableCars cars)
        {
            _fetchAvailableCars = cars;
        }

        [HttpGet]
        [Route("api/car/available")]
        public async Task<GetCarsResponse> Get()
        {
            var cars =  await _fetchAvailableCars.Fetch();
            return new GetCarsResponse(
                cars.Cars.Select(
                    car => new AvailableCar(
                        car.License,
                        car.Model.Name,
                        car.Model.RentType.PricePolicy.Name
                )
            ).ToList());
        }
    }
}