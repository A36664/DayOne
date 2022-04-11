using BookStore.Applications.Repositories;
using BookStore.Data.EF;

namespace BookStore.Applications
{
    public class UnitOfWork
    {
        private OrderRepository _orderRepository;
        private CustomerRepository _customerRepository;
        private BookStoreContext _context;
        public UnitOfWork(BookStoreContext context)
        {
            _context = context;
        }
        public CustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_context);
                }

                return _customerRepository;
            }
        }

        public OrderRepository orderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_context);
                }

                return _orderRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
