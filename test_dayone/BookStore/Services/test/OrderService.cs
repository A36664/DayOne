using BookStore.Data.Entities;
using BookStore.Infrastructure;
using BookStore.Models.Carts;
using BookStore.Repositories;
using System.Threading.Tasks;

namespace BookStore.Services.test
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        IUnitOfWork _unitOfWork;
       
        public OrderService(IOrderRepository orderRepository,IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> CreateOrder(CheckoutRequest request)
        {
            var customer = new Customer()
            {
                Email = request.Email,
                Name = request.CustomerName,
                PhoneNumber = request.PhoneNumber
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            var listInput = request.OrderDetails.Select(x => new Input()
            {
                BookId = x.BookId,
                Total = x.Quantity,
                DateIn = DateTime.Now
            });

            await _context.Inputs.AddRangeAsync(listInput);
            await _context.SaveChangesAsync(true);

            var order = new Order()
            {
                CustomerId = customer.Id,
                OrderDetails = request.OrderDetails.Select(x => new OrderDetails() { BookId = x.BookId, Quantity = x.Quantity, Price = x.Price }).ToList(),
            };


            _context.Orders.Add(order);


            var item = await _context.SaveChangesAsync();

            return item;
        }
    }
}
