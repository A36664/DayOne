using BookStore.Data.EF;
using BookStore.Data.Entities;
using BookStore.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICustomerService _customerService;
        private readonly BookStoreContext _context;

        public OrderService(ICustomerService customerService, BookStoreContext context)
        {
            _customerService = customerService;
            _context = context;
        }

        public async Task<int> CreateOrder(CheckoutRequest request)
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

           await  _context.Inputs.AddRangeAsync(listInput);
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
