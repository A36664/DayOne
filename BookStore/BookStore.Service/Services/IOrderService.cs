using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;

namespace BookStore.Service.Services
{
    public interface IOrderService : IBaseService<Order>
    {
        List<OrderViewModel> GetAllOrder();
    }
}
