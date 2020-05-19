using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Moq;
using Xunit;

namespace IntegrationTests
{
    public class ReturnCarsTest
    {
        [Fact]
        public async void Test()
        {
            var carRepository = new Mock<ICarRepository>();
            var customerRepository = new Mock<ICustomerRepository>();
            
            var priceCalculator = new CarPriceCalculator();

            var pricePolicy1 = new PricePolicy("premium", 150);
            var pricePolicy2 = new PricePolicy("base", 100);
            
            var rentType1 = new RentType("convertible", 2, pricePolicy1);
            var rentType2 = new RentType("minivan", 1, pricePolicy2, TimeSpan.FromDays(5), 0.2m);
            
            var model1 = new CarModel("Volvo", "C-70", rentType1);
            var model2 = new CarModel("Ford", "Galaxy", rentType2);
            
            var car1 = new Car("HGJ-5566", model1);
            var car2 = new Car("JKL-1235", model2);

            var now = DateTime.Now;
            var daysAfter = now.AddDays(8);
            
            var carRents = new List<CarRent>
            {
                new CarRent("HGJ-5566", now, now.AddDays(5), 750, 2, now, 0, CarRentStatus.Pending),
                new CarRent("JKL-1235", now, now.AddDays(3), 300, 1, now, 0, CarRentStatus.Pending)
            };
            customerRepository.Setup(r => r.FindByName("Luke Skywalker")).ReturnsAsync(new Customer("Luke Skywalker", carRents));
            
            carRepository.Setup(r => r.FindById("HGJ-5566")).ReturnsAsync(car1);
            carRepository.Setup(r => r.FindById("JKL-1235")).ReturnsAsync(car2);
            
            var useCase = new ReturnCars(carRepository.Object, customerRepository.Object, priceCalculator);

            var request = new ReturnRequest("Luke Skywalker", new List<string>{ "HGJ-5566", "JKL-1235" }, daysAfter);
            var response = await useCase.Return(request);

            var returnedCars = new List<ReturnedCar>
            {
                new ReturnedCar("HGJ-5566", "Volvo", "C-70", 5, 3, 750, 1200, 2),
                new ReturnedCar("JKL-1235", "Ford", "Galaxy", 3, 5, 300, 740, 1),
            };
            Assert.Equal(returnedCars, response.ReturnedCars.ToList());
            Assert.Equal(1050, response.TotalPriceContracted);
            Assert.Equal(1940, response.TotalPayed);
            Assert.Equal(3, response.TotalBonus);
            
            var updatedCarRents = new List<CarRent>
            {
                new CarRent("HGJ-5566", now, now.AddDays(5), 750, 2, now.AddDays(8), 1200, CarRentStatus.Payed),
                new CarRent("JKL-1235", now, now.AddDays(3), 300, 1, now.AddDays(8), 740, CarRentStatus.Payed)
            };
            var savedCustomer = new Customer("Luke Skywalker", updatedCarRents);
            customerRepository.Verify(m => m.FindByName("Luke Skywalker"), Times.Once);
            customerRepository.Verify(m => m.Update(savedCustomer), Times.Once);
            
            var updatedCars = new List<Car>
            {
                new Car("HGJ-5566", true, model1),
                new Car("JKL-1235", true, model2)
            };
            carRepository.Verify(m => m.Update(updatedCars), Times.Once);
        }
    }
}