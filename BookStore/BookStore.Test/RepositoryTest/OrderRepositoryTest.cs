using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using BookStore.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BookStore.Test.RepositoryTest
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private IDbFactory _dbFactory;
        private IOrderRepository _orderRepository;
        private IUnitOfWork _unitOfWork;


        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _orderRepository = new OrderRepository(_dbFactory);
            _unitOfWork = new UnitOfWork(_dbFactory);
        }

        [TestMethod]
        public void Order_Repository_GetAll()
        {
            var books = _orderRepository.GetAllOrders().ToList();
            Assert.IsNotNull(books);
            Assert.IsTrue(books.Count > 0);
        }
        [TestMethod]
        public void Order_Repository_Add()
        {
            var order = new Order()
            {
                CustomerId = 1

            };
            var result = _orderRepository.Add(order);
            _unitOfWork.Commit();
            Assert.IsNotNull(result);
        }
    }
}
