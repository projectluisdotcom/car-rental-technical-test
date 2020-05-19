using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FleetContext _context;

        public CustomerRepository(FleetContext context)
        {
            _context = context;
        }
        
        public async Task<Customer> FindByName(string userName)
        {
            return await _context.Customers
                .Where(customer => customer.Name.Equals(userName))
                .SingleAsync();
        }

        public async Task Save(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public async Task Update(Customer customer)
        {
            _context.Set<Customer>().Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}