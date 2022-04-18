using BookStore.Data.Infrastructure;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Data.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }


        public List<OrderViewModel> GetAllOrders()
        {

            var orders = DbContext.Orders.Include(cu => cu.Customer).Include(od => od.OrderDetails.Select(x => x.Book))
                .Select(x => new OrderViewModel()
                {
                    OrderDetails = x.OrderDetails.ToList(),
                    CustomerPhoneNumber = x.Customer.PhoneNumber,
                    CustomerEmail = x.Customer.Email,
                    CustomerName = x.Customer.Name,
                    OrderId = x.OrderId

                }).ToList();





            return orders;
        }
    }
}
