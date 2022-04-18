using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using System.Collections.Generic;

namespace BookStore.Service.Services
{
    public interface IOrderService : IBaseService<Order>
    {
        List<OrderViewModel> GetAllOrder();

        Order Create(Order order, List<OrderDetail> orderDetails);
    }
}
