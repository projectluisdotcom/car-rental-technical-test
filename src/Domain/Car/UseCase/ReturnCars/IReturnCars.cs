using System.Threading.Tasks;

namespace Domain
{
    public interface IReturnCars : IUseCase
    {
        Task<ReturnSummary> Return(ReturnRequest request);
    }
}