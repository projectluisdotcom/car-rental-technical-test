using System.Collections.Generic;
using System.Linq;
using Domain;
using Moq;
using Xunit;

namespace IntegrationTests
{
    public class FetchAvailableCarsTest
    {
        [Fact]
        public async void Test()
        {
            var carRepository = new Mock<ICarRepository>();

            var pricePolicy = new PricePolicy("base", 100);
            var rentType = new RentType("suv", 1, pricePolicy);
            var model = new CarModel("Mazda", "CX-5", rentType);
            var car = new Car("HGJ-5566", model);
            
            carRepository.Setup(r => r.FindAll()).ReturnsAsync(new List<Car>{ car });
            
            var useCase = new FetchAvailableCars(carRepository.Object);

            var response = await useCase.Fetch();
            
            var availableCars = response.Cars.ToList();
            var expected = new List<Car> {car};
            
            Assert.Equal(expected, availableCars);
        }
    }
}
