using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using BookStore.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
            _mockUnitOfWork= new Mock<IUnitOfWork>();
            _bookService = new BookService(_mockBookRepository.Object, _mockUnitOfWork.Object);
            _bookViewModel = new List<BookViewModel>()
            {
                new BookViewModel(){Price = 456.45m,AuthorId = 1,OriginalPrice = 145.6m,Stock = 450,CategoryId = 1,Name = "Book 1",AuthorName = "author 1",CategoryName = "category 1",Id = 1},
                new BookViewModel(){Price = 145.45m,AuthorId = 1,OriginalPrice = 145.6m,Stock = 450,CategoryId = 3,Name = "Book 2",AuthorName = "author 2",CategoryName = "category 3",Id = 2},
                new BookViewModel(){Price = 345.45m,AuthorId = 1,OriginalPrice = 145.6m,Stock = 450,CategoryId = 2,Name = "Book 3",AuthorName = "author 3",CategoryName = "category 2",Id = 3},
                new BookViewModel(){Price = 123.45m,AuthorId = 1,OriginalPrice = 145.6m,Stock = 450,CategoryId = 3,Name = "Book 4",AuthorName = "author 4",CategoryName = "category 3",Id = 4},
                new BookViewModel(){Price = 567.45m,AuthorId = 1,OriginalPrice = 145.6m,Stock = 450,CategoryId = 2,Name = "Book 5",AuthorName = "author 5",CategoryName = "category 2",Id = 5}
            };
            _books = new List<Book>()
            {
                new Book()
                {
                    Id = 1, AuthorId = 1, Name = "Book 1", Price = 456.45m, OriginalPrice = 145.6m, CategoryId = 2,
                    Stock = 450
                },
                new Book()
                {
                    Id = 2, AuthorId = 2, Name = "Book 2", Price = 345.45m, OriginalPrice = 145.6m, CategoryId = 1,
                    Stock = 345
                },
                new Book()
                {
                    Id = 3, AuthorId = 3, Name = "Book 3", Price = 674.45m, OriginalPrice = 145.6m, CategoryId = 2,
                    Stock = 145
                },
                new Book()
                {
                    Id = 4, AuthorId = 1, Name = "Book 4", Price = 156.45m, OriginalPrice = 89.6m, CategoryId = 3,
                    Stock = 789
                },
                new Book()
                {
                    Id = 5, AuthorId = 2, Name = "Book 5", Price = 256.45m, OriginalPrice = 145.6m, CategoryId = 1,
                    Stock = 267
                }
            };

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
            Assert.AreEqual(1,result.Id);
        }
    }
}
