using BookStore.Data.Infrastructure;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using System.Collections.Generic;

namespace BookStore.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<OrderViewModel> GetAllOrders();
    }
}
