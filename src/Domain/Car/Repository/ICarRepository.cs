using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public interface ICarRepository
    {
        Task Save(Car car);
        Task<List<Car>>  FindAll();
        Task<Car> FindFirstByModelAndFree(string model, bool free);
        Task<Car> FindById(string model);
        Task Update(Car car);
        Task Update(IEnumerable<Car> cars);
    }
}