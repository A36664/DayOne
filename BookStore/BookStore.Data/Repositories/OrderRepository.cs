using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Odbc;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Infrastructure;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;

namespace BookStore.Data.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }


        public List<OrderViewModel> GetAllOrders()
        {

            //object query;
            //query = DbContext.Customers.Include(x => x.Orders.Select(od => od.OrderDetails.Select(b => b.Book)).Select(h => new OrderViewModel()
            //{
            //    BookId = h.
            //}))

            return new List<OrderViewModel>();
        }
    }
}
