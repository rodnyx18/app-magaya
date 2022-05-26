using Microsoft.EntityFrameworkCore;
using MWebApi.Contexts;
using MWebApi.Entities;
using MWebApi.Exceptions;

namespace MWebApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private OrdersDBContext _context = default!;

        public CustomerRepository(OrdersDBContext context)
        {
            _context = context;
        }

        public async Task<Customer> Add(Customer customer)
        {
            if (customer.Name.ToLower() == "error")
            {
                throw new Exception("An unexpected error has been thrown.");
            }

            if (_context.Customers.AnyAsync(c => c.Email == customer.Email).Result)
            {
                throw new FunctionalException("Customer cannot be created: Email is already in use.", 403);
            }

            if (_context.Customers.AnyAsync(c => c.Phone == customer.Phone).Result)
            {
                throw new FunctionalException("Customer cannot be created: Phone number is already in use.", 403);
            }

            _context.Addresses.Add(customer.Address!);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return await _context
                .Customers
                .Include(c => c.Address)
                .FirstAsync(c => c.Id == customer.Id);          
        }

        public async Task<bool> Delete(int id)
        {
            if (_context.Orders.AnyAsync(o => o.CustomerId == id).Result)
            {
                throw new FunctionalException("The customer has orders in progress and cannot be removed.", 403);
            }

            var customer = await _context.Customers.FindAsync(id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Customer?> Get(int id)
        {
            var customer = await _context
                .Customers
                .Include(c => c.Address)
                .Include(c => c.Orders)
                .FirstAsync(c => c.Id == id);

            return customer;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task Update(int id, Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
