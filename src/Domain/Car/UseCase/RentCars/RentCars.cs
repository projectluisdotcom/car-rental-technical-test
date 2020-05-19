using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.UseCase;

namespace Domain
{
    public class RentCars : IRentCars
    {
        private readonly ICarRepository _carRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICarPriceCalculator _carPriceCalculator;
        private readonly ICarBonusCalculator _carBonusCalculator;

        public RentCars(ICarRepository carRepository, ICustomerRepository customerRepository, ICarPriceCalculator carPriceCalculator, ICarBonusCalculator carBonusCalculator)
        {
            _carRepository = carRepository;
            _customerRepository = customerRepository;
            _carPriceCalculator = carPriceCalculator;
            _carBonusCalculator = carBonusCalculator;
        }
        
        public async Task<ContractedCars> Rent(RentedCars rentedCars)
        {
            var customer = await _customerRepository.FindByName(rentedCars.UserName);
            if (customer == null)
            {
                throw new NotFoundException();
            }

            var updatedCars = new List<Car>();
            var cars = new List<ContractCar>();
            var busyCars = new List<string>();
            
            // TODO: Use Flux to benefit from async
            foreach (var request in rentedCars.RentRequests)
            {
                await ProcessRequest(request, customer, rentedCars.Now, busyCars, cars, updatedCars);
            }
            
            var updateCars = _carRepository.Update(updatedCars);
            var updateCustomer = _customerRepository.Update(customer);

            Task.WaitAll(updateCars, updateCustomer);

            var totalCost = cars.Sum(c => c.ContractedPrice);
            var totalBonus = cars.Sum(c => c.BonusWon);
            return new ContractedCars(cars, busyCars, totalCost, totalBonus);
        }

        private async Task ProcessRequest(
            RentRequest request, 
            Customer customer,
            DateTime now, 
            ICollection<string> notFoundCars,
            ICollection<ContractCar> cars,
            ICollection<Car> updatedCars
        )
        {
            var freeCar = await _carRepository.FindFirstByModelAndFree(request.Model, true);
            if (freeCar == null)
            {
                notFoundCars.Add(request.Model);
                return;
            }

            var price = _carPriceCalculator.Calculate(freeCar.Model.RentType, request.Days);
            var bonus = _carBonusCalculator.Calculate(freeCar.Model.RentType);
            freeCar.Rent();
            
            updatedCars.Add(freeCar);

            var carRent = new CarRent(
                freeCar.License,
                now,
                price,
                bonus,
                request.Days
            );
            customer.CarRents.Add(carRent);

            cars.Add(new ContractCar(
                freeCar.License,
                freeCar.Model.Name,
                freeCar.Model.Brand,
                request.Days,
                price,
                bonus
            ));
        }
    }
}
