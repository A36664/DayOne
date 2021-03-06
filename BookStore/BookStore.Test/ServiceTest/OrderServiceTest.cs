using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using BookStore.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using BookStore.Shared;

namespace BookStore.Test.ServiceTest
{
    [TestClass]
    public class OrderServiceTest
    {
        private Mock<IOrderRepository> _mockOrderRepository;
        private Mock<IOrderDetailRepository> _mockOrderDetailRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private List<OrderViewModel> _orderViewModels;
        private IOrderService _orderService;

        [TestInitialize]
        public void Initialize()
        {
            _mockOrderDetailRepository = new Mock<IOrderDetailRepository>();
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _orderService = new OrderService(_mockOrderRepository.Object, _mockUnitOfWork.Object, _mockOrderDetailRepository.Object);
            _orderViewModels = Commons.OrderViewModels();
        }

        [TestMethod]
        public void Order_Service_GetAll()
        {
            // arrange
            _mockOrderRepository.Setup(m => m.GetAllOrders()).Returns(_orderViewModels);

            // act
            var books = _orderService.GetAllOrder() as List<OrderViewModel>;

            // assert
            Assert.IsNotNull(books);
            Assert.IsTrue(books.Count > 0);
        }
        [TestMethod]
        public void Order_Service_Create()
        {

            var order = new Order()
            {
                CustomerId = 1

            };
            var orderDetails = new List<OrderDetail>()
            {
                new OrderDetail(){ Price = 450.4m,
                    BookId = 1,
                    OrderId = 1,
                    Quantity = 150},
                new OrderDetail(){ Price = 145.4m,
                    BookId = 2,
                    OrderId = 1,
                    Quantity = 450}

            };
            var newOrder = _mockOrderRepository.Setup(m => m.Add(order)).Returns((Order od) =>
              {
                  od.OrderId = 1;
                  return od;
              });
            _mockUnitOfWork.Object.Commit();



            foreach (var newOrderDetail in orderDetails)
            {
                _mockOrderDetailRepository.Setup(m => m.Add(newOrderDetail)).Returns((OrderDetail odd) => odd);
            }



            var result = _orderService.Create(order, orderDetails);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.OrderId);
        }
    }
}
