using BookStore.Controllers;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.Test.ControllersTest
{
    public class BookControllerTest
    {
        private readonly Mock<IBookService> _bookServiceMock;
        private static BookViewModel _bookViewModel = new BookViewModel()
        {
            AuthorName = "nguyen van luc",
            CategoryName = "category 1",
            Id = 1,
            OriginalPrice = 15,
            Price = 13,
            Stock = 24,
            Name = "sach 1"
        };

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
        public async void GetDetails_ValidInput_Notnull()
        {
            // arrange
            _bookServiceMock.Setup(repo => repo.GetBookById(It.IsAny<int>())).ReturnsAsync(new BookViewModel()
            {
                AuthorName = "nguyen van luc",
                CategoryName = "category 1",
                Name = "sach 1"
            });

            var controller = new BookController(_bookServiceMock.Object);
            var result = await controller.Details(1) as ViewResult;

            // assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<BookViewModel>(result.Model);
            Assert.NotNull(model);
            Assert.IsType<BookViewModel>(model);



        }
        [Fact]
        public async void GetDetails_InValidInputt_Failed()
        {
            // arrange
            _bookServiceMock.Setup(repo => repo.GetBookById(-1 * It.IsAny<int>())).ReturnsAsync(new BookViewModel());

            var controller = new BookController(_bookServiceMock.Object);
            var result = await controller.Details(-1 * It.IsAny<int>()) as ViewResult;

            // assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<BookViewModel>(result.Model);
            Assert.NotNull(model);
            Assert.IsType<BookViewModel>(model);



        }

        [Fact]
        public async Task GetBooksPaging_ValidInput_Success()
        {
            // arrange
            _bookServiceMock.Setup(repo => repo.GetListBookByPaging(1, 10)).ReturnsAsync(new List<BookViewModel>() { _bookViewModel });
            BookController bookController = new BookController(_bookServiceMock.Object);

            // act
            var result = await bookController.GetBooksPaging();

            RedirectToRouteResult routeResult = result as RedirectToRouteResult;

            // assert
            Assert.NotNull(result);

            var booksController = new BookController(_bookServiceMock.Object);
        }
        [Fact]
        public async Task Edit_ValidInput_Success()
        {
            var bookViewModel = new BookViewModel() { AuthorName = "nguyen van luc", CategoryName = "category 1", Id = 1, OriginalPrice = 15, Price = 13, Stock = 24 };
            _bookServiceMock.Setup(repo => repo.Update(bookViewModel)).ReturnsAsync(bookViewModel);
            BookController bookController = new BookController(_bookServiceMock.Object);

            // act
            var result = await bookController.Edit(bookViewModel) as RedirectResult;

            // assert
            Assert.True(result.Url == "/");

        }
        [Fact]
        public async Task EditView_HasData_Success()
        {
           
            _bookServiceMock.Setup(repo => repo.GetBookById(It.IsAny<int>())).ReturnsAsync(_bookViewModel);
            BookController bookController = new BookController(_bookServiceMock.Object);

            // act
            var result = await bookController.EditView(It.IsAny<int>()) as ViewResult;

            // assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<BookViewModel>(result.Model);
            Assert.NotNull(model);
            Assert.IsType<BookViewModel>(model);
        }

        [Fact]
        public async Task Delete_ValidInput_Success()
        {
          
            _bookServiceMock.Setup(repo => repo.Delete(It.IsAny<int>())).ReturnsAsync((int first)=>first);


            BookController bookController = new BookController(_bookServiceMock.Object);
            // act
            var result = await bookController.Delete(1);
            //assert
            Assert.IsType<RedirectResult>(result);
            Assert.True((result as RedirectResult).Url == "/");


        }
        [Fact]
        public async Task Delete_ValidInput_Failed()
        {

            _bookServiceMock.Setup(repo => repo.Delete(-1)).ReturnsAsync((int first) => first);


            BookController bookController = new BookController(_bookServiceMock.Object);
            // act
            var result = await bookController.Delete(It.IsAny<int>());
            //assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);



        }
    }
}
