using BookStore.Data.EF;
using BookStore.Data.Entities;

namespace BookStore.Applications.Repositories
{
    public class OrderRepository
    {
        private BookStoreContext _context;
        public OrderRepository(BookStoreContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public void Remove(Order order)
        {
            _context.Orders.Remove(order);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
