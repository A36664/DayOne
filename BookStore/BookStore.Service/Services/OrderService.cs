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
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IUnitOfWork _unitOfWork;
        private static readonly ILog Log = LogHelper.GetLogger();
        public OrderService(IOrderRepository orderRepository,IUnitOfWork unitOfWork, IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository=orderRepository;
            _unitOfWork = unitOfWork;
            _orderDetailRepository = orderDetailRepository;
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

        public Order Add(Order customer)
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

        public Order Create(Order order, List<OrderDetail> orderDetails)
        {
            try
            {
                _orderRepository.Add(order);
                _unitOfWork.Commit();

                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.OrderId = order.OrderId;
                    _orderDetailRepository.Add(orderDetail);
                }
                
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception();
            }
            return order;
        }
    }
}
