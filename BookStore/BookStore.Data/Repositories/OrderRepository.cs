using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Odbc;
using System.Diagnostics;
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


            var orders = DbContext.Orders.Include(od => od.Customer).Include(x=>x.OrderDetails.Select(od=>od.Book)).ToList();
           
            

            return new List<OrderViewModel>();
        }
    }
}
