using BookStore.Data.EF;
using BookStore.Data.Entities;

namespace BookStore.Applications.Repositories
{
    public class CustomerRepository
    {
        private BookStoreContext _context;
        public CustomerRepository(BookStoreContext context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Remove(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}
