using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using BookStore.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStore.Test.RepositoryTest
{
    [TestClass]
    public class BookRepositoryTest
    {
        private IDbFactory _dbFactory;
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork;


        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _bookRepository = new BookRepository(_dbFactory);
            _unitOfWork = new UnitOfWork(_dbFactory);
        }
        [TestMethod]
        public void Book_Repository_GetAll()
        {
            var books = _bookRepository.GetAllBooks().ToList();
            Assert.IsNotNull(books);
            Assert.IsTrue(books.Count>0);
        }
        [TestMethod]
        public void Book_Repository_Add()
        {
            var book = new Book
            {
                Name = "book2",
                CategoryId = 1,
                AuthorId = 2,
                Price = 456.5m,
                OriginalPrice = 150.67m,
                Stock = 345
            };
            var result = _bookRepository.Add(book);
            _unitOfWork.Commit();
            Assert.IsNotNull(result);
        }
    }
}
