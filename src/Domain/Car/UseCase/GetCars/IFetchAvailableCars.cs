using System.Threading.Tasks;

namespace Domain
{
    public interface IFetchAvailableCars : IUseCase
    {
        Task<AvailableCars> Fetch();
    }
}