using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.UseCase;

namespace Domain
{
    public class ReturnCars : IReturnCars
    {
        private readonly ICarRepository _carRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICarPriceCalculator _carPriceCalculator;

        public ReturnCars(ICarRepository carRepository, ICustomerRepository customerRepository, ICarPriceCalculator carPriceCalculator)
        {
            _carRepository = carRepository;
            _customerRepository = customerRepository;
            _carPriceCalculator = carPriceCalculator;
        }
        
        public async Task<ReturnSummary> Return(ReturnRequest request)
        {
            var customer = await _customerRepository.FindByName(request.UserName);
            if (customer == null)
            {
                throw new NotFoundException();
            }

            var updatedCars = new List<Car>();
            var returnedCars = new List<ReturnedCar>();
            
            // TODO: Use a Stream to benefit from async
            foreach (var licenseNumber in request.LicenseNumbers)
            {
                await ReturnCar(customer, licenseNumber, request.Now, updatedCars, returnedCars);
            }
            
            var updateCars = _carRepository.Update(updatedCars);
            var updateCustomer = _customerRepository.Update(customer);

            Task.WaitAll(updateCars, updateCustomer);

            var totalPriceContracted = returnedCars.Sum(c => c.ContractedPrice);
            var totalPayed = returnedCars.Sum(c => c.TotalPayed);
            var totalBonus = returnedCars.Sum(c => c.BonusWon);
            return new ReturnSummary(returnedCars, totalPriceContracted, totalPayed, totalBonus);
        }
        private async Task ReturnCar(
            Customer customer,
            string licenseNumber,
            DateTime now,
            ICollection<Car> updatedCars,
            ICollection<ReturnedCar> returnedCars
        )
        { 
            var returnedCar = customer.CarRents.First(c => c.CarId == licenseNumber);
            if (returnedCar == null)
            {
                return;
            }

            var car = await _carRepository.FindById(returnedCar.CarId);
            if (car == null)
            {
                throw new NotFoundException();
            }
            
            car.Free();

            var totalTime = returnedCar.CalculateTotalTime(now);
            var price = _carPriceCalculator.Calculate(car.Model.RentType, totalTime.Days);
            returnedCar.Returned(price, now);

            updatedCars.Add(car);
            returnedCars.Add(new ReturnedCar(
                car.License,
                car.Model.Name,
                car.Model.Brand,
                returnedCar.GetContractedDays(),
                returnedCar.GetOvertimeDays(),
                returnedCar.ContractedPrice,
                returnedCar.PricePayed,
                returnedCar.BonusWon
            ));
        }
    }
}