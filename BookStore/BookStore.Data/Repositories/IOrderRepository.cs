using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Infrastructure;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;

namespace BookStore.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<OrderViewModel> GetAllOrders();
    }
}
