using System.Threading.Tasks;

namespace Domain
{
    public interface ICustomerRepository
    {
        Task<Customer> FindByName(string userName);
        Task Save(Customer customer);
        Task Update(Customer customer);
    }
}