using System.Threading.Tasks;

namespace Domain
{
    public interface IRentCars : IUseCase
    {
        Task<ContractedCars> Rent(RentedCars rentedCars);
    }
}