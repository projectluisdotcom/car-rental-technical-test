using System.Threading.Tasks;

namespace Domain
{
    public class FetchAvailableCars : IFetchAvailableCars
    {
        private readonly ICarRepository _carRepository;

        public FetchAvailableCars(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        
        public async Task<AvailableCars> Fetch()
        {
            var cars = await _carRepository.FindAll();
            return new AvailableCars(cars);
        }
    }
}