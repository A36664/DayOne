using BookStore.Data.EF;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly BookStoreContext _context;
        public CustomerService(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
                _context.Customers.Remove(customer);
            return await _context.SaveChangesAsync();

        }

        public async Task<CustomerViewModel> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            var result = new CustomerViewModel()
            {
                Email = customer.Email,
                Id = customer.Id,
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
            };

            return result;

        }

        public async Task<List<CustomerViewModel>> GetCustomerPaging(int page, int pageSize)
        {
            var query = _context.Customers;

            var customers = await query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new CustomerViewModel()
            {
                Email = x.Email,
                Id = x.Id,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
            }).ToListAsync();
            return customers;
        }

        public async Task<CustomerViewModel> Update(CustomerViewModel request)
        {
            var customer = await _context.Customers.FindAsync(request.Id);
            if (customer != null)
            {
                customer.PhoneNumber = request.PhoneNumber;
                customer.Name = request.Name;
                customer.Email = request.Email;
                _context.Customers.Update(customer);

            }

            await _context.SaveChangesAsync();

            return request;
        }
    }
}
