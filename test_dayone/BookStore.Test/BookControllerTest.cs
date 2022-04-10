using BookStore.Controllers;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.Test
{
    public class BookControllerTest
    {
        private readonly Mock<IBookService> _bookServiceMock;
        public BookControllerTest()
        {
            _bookServiceMock = new Mock<IBookService>();
        }

        [Fact]
        public void BookController_CreateInstance_NotNull()
        {
            var mokBook = new Mock<IBookService>();
            var booksController = new BookController(_bookServiceMock.Object);
            Assert.NotNull(booksController);
        }
        [Fact]
        public async Task GetBooksPaging_ValidInput_Success()
        {
            var mockRepo = new Mock<IBookService>();
            mockRepo.Setup(repo => repo.GetListBookByPaging(1, 10)).ReturnsAsync(new List<Models.BookViewModel>()
            {
                new Models.BookViewModel(){Id=1,AuthorName="nguyen van luc",CategoryName="truyen tranh",Name="sach 1", OriginalPrice=15,Price=13,Stock=24},
            });
            BookController bookController = new BookController(_bookServiceMock.Object);
            var result = await bookController.GetBooksPaging();

            RedirectToRouteResult routeResult = result as RedirectToRouteResult;


            Assert.NotNull(result);

            var booksController = new BookController(_bookServiceMock.Object);
        }
    }
}
