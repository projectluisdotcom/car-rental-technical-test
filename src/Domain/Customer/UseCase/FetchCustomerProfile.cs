using System.Threading.Tasks;

namespace Domain.UseCase
{
    public class FetchCustomerProfile : IFetchCustomerProfile
    {
        private readonly ICustomerRepository _customerRepository;

        public FetchCustomerProfile(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public async Task<Customer> Fetch(string userName)
        {
            var customer = await _customerRepository.FindByName(userName);
            if (customer == null)
            {
                throw new NotFoundException();
            }

            return customer;
        }
    }
}