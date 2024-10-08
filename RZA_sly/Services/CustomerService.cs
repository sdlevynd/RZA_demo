using RZA_sly.Models;
using Microsoft.EntityFrameworkCore;

namespace RZA_sly.Services
{
    public class CustomerService
    {
        private readonly TlSlyRzaContext _context;
        public CustomerService(TlSlyRzaContext context) 
        {
            _context = context;
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerFromIdAsync(int id)
        {
            return await _context.Customers.FirstAsync(c => c.CustomerId == id);
        }
        public async Task<Customer> LogIn(Customer customer)
        {
            return await _context.Customers.FirstAsync(
                c => c.Username == customer.Username &&
                c.Password == customer.Password);
        }
    }
}
