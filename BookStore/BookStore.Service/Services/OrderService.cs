using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using BookStore.Shared.Helpers;
using log4net;

namespace BookStore.Service.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private static readonly ILog Log = LogHelper.GetLogger();
        public OrderService(IOrderRepository orderRepository,IUnitOfWork unitOfWork)
        {
            _orderRepository=orderRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order customer)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Add(Order customer)
        {
            throw new NotImplementedException();
        }

        public List<OrderViewModel> GetAllOrder()
        {
            Log.Info("Begin: GetAllOrder");
            var orders=_orderRepository.GetAllOrders();
            Log.Info("End: GetAllOrder");
            return orders;

        }
    }
}
