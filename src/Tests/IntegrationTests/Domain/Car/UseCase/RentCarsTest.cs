using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Moq;
using Xunit;

namespace IntegrationTests
{
    public class RentCarsTest
    {
        [Fact]
        public async void Test()
        {
            var carRepository = new Mock<ICarRepository>();
            var customerRepository = new Mock<ICustomerRepository>();
            
            var priceCalculator = new CarPriceCalculator();
            var bonusCalculator = new CarBonusCalculator();
            
            var pricePolicy1 = new PricePolicy("premium", 150);
            var pricePolicy2 = new PricePolicy("base", 100);
            
            var rentType1 = new RentType("convertible", 2, pricePolicy1);
            var rentType2 = new RentType("minivan", 1, pricePolicy2, TimeSpan.FromDays(5), 0.2m);
            
            var model1 = new CarModel("C-70", "Volvo", rentType1);
            var model2 = new CarModel("Galaxy", "Ford", rentType2);
            
            var car1 = new Car("HGJ-5566", model1);
            var car2 = new Car("JKL-1235", model2);
            var car3 = new Car("FDG-9034", model2);
            
            var now = DateTime.Now;;
          
            Car noCar = null;
            carRepository.Setup(r => r.FindFirstByModelAndFree("C-70", true)).ReturnsAsync(car1);
            carRepository.Setup(r => r.FindFirstByModelAndFree("Galaxy", true)).ReturnsAsync(car2);
            carRepository.Setup(r => r.FindFirstByModelAndFree("GTR R36", false)).ReturnsAsync(car3);
            carRepository.Setup(r => r.FindFirstByModelAndFree("NoExists", true)).ReturnsAsync(noCar);
            
            customerRepository.Setup(r => r.FindByName("Luke Skywalker")).ReturnsAsync(new Customer("Luke Skywalker"));
            
            var useCase = new RentCars(carRepository.Object, customerRepository.Object, priceCalculator, bonusCalculator);

            var rentRequests = new List<RentRequest>{ 
                new RentRequest("C-70", 10),
                new RentRequest("Galaxy", 8),
                new RentRequest("GTR R36", 1),
                new RentRequest("NoExists", 1)
            };
            var request = new RentedCars("Luke Skywalker", rentRequests, now);
            var response = await useCase.Rent(request);

            Assert.Equal(new List<string>{"GTR R36", "NoExists"}, response.NotFoundCars.ToList());
            Assert.Equal(2240, response.TotalCost);
            Assert.Equal(3, response.TotalBonus);

            var confirmedRents = new List<ContractCar>
            {
                new ContractCar("HGJ-5566", "C-70", "Volvo", 10, 1500, 2),
                new ContractCar("JKL-1235", "Galaxy", "Ford", 8, 740, 1)
            };
            Assert.Equal(confirmedRents, response.ConfirmedRents.ToList());
            
            var updatedCarRents = new List<CarRent>
            {
                new CarRent("HGJ-5566", now, now.AddDays(10), 1500, 1, now, 0, CarRentStatus.Pending),
                new CarRent("JKL-1235", now, now.AddDays(8), 740, 2, now, 0, CarRentStatus.Pending)
            };
            var updatedCustomer = new Customer("Luke Skywalker", updatedCarRents);
            customerRepository.Verify(m => m.FindByName("Luke Skywalker"), Times.Once);
            customerRepository.Verify(m => m.Update(updatedCustomer), Times.Once);

            var updatedCars = new List<Car>
            {
                new Car("HGJ-5566", false, model1),
                new Car("JKL-1235", false, model2),
            };
            carRepository.Verify(m => m.Update(updatedCars), Times.Once);
        }
    }
}