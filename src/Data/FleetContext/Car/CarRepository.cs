using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CarRepository : ICarRepository
    {
        private readonly FleetContext _context;

        public CarRepository(FleetContext context)
        {
            _context = context;
        }

        public async Task Save(Car car)
        {
            await _context.Cars.AddAsync(car);
        }

        public async Task<List<Car>> FindAll()
        {
            return await _context.Set<Car>()
                .Include(c => c.Model)
                .Include(c => c.Model.RentType)
                .Include(c => c.Model.RentType.PricePolicy)
                .ToListAsync();
        }

        public async Task<Car> FindFirstByModelAndFree(string model, bool free)
        {
            return await _context.Cars
                .FirstOrDefaultAsync(car => car.Model.Name.Equals(model) && car.IsFree == free);
        }

        public async Task<Car> FindById(string model)
        {
            return await _context.Cars
                .FirstOrDefaultAsync(car => car.License.Equals(model));
        }

        public async Task Update(Car car)
        {
            _context.Set<Car>().Update(car);
            await _context.SaveChangesAsync();
        }
        
        public async Task Update(IEnumerable<Car> cars)
        {
            foreach (var car in cars)
            {
                _context.Set<Car>().Update(car);
            }
            await _context.SaveChangesAsync();
        }
    }
}