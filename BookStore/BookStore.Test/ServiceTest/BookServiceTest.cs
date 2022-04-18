using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using BookStore.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Security.AccessControl;
using BookStore.Shared;

namespace BookStore.Test.ServiceTest
{
    [TestClass]
    public class BookServiceTest
    {
        private Mock<IBookRepository> _mockBookRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private List<Book> _books;
        private List<BookViewModel> _bookViewModel;
        private IBookService _bookService;

        [TestInitialize]
        public void Initialize()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _bookService = new BookService(_mockBookRepository.Object, _mockUnitOfWork.Object);
            _bookViewModel = Commons.GetBookViewModels();
            _books = Commons.GetBooks();

        }
        [TestMethod]
        public void Book_Service_GetAll()
        {
            // arrange
            _mockBookRepository.Setup(m => m.GetAllBooks()).Returns(_bookViewModel);

            // act
            var books = _bookService.GetAllBooks() as List<BookViewModel>;

            // assert
            Assert.IsNotNull(books);
            Assert.IsTrue(books.Count > 0);
        }
        [TestMethod]
        public void Book_Service_Create()
        {
            var book = new Book()
            {
                Price = 456.34m,
                OriginalPrice = 145.45m,
                Stock = 456,
                CategoryId = 1,
                AuthorId = 2,
                Name = "Book 1"

            };
            _mockBookRepository.Setup(m => m.Add(book)).Returns((Book b) =>
            {
                b.Id = 1;
                return b;
            });

            var result = _bookService.Add(book);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }
    }
}
