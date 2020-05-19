using System.Threading.Tasks;

namespace Domain.UseCase
{
    public interface IFetchCustomerProfile : IUseCase
    {
        Task<Customer> Fetch(string userName);
    }
}