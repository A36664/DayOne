using BookStore.Model.Entities;
using BookStore.Service.Services;
using BookStore.Shared;
using BookStore.Shared.Helpers;
using log4net;
using System;
using System.Collections.Generic;
using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using BookStore.Model.ViewModels;
using Moq;

namespace BookStore.Service
{
    public class MainHandler : IMainHandler
    {

        private readonly ICustomerService _customerService;
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private static readonly ILog Log = LogHelper.GetLogger();

        //fake data
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private List<Book> _books;
        private readonly List<BookViewModel> _bookViewModel;

        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IOrderDetailRepository> _mockOrderDetailRepository;
        private readonly List<OrderViewModel> _orderViewModels;


        public MainHandler(ICustomerService customerService, IBookService bookService, IAuthorService authorService, ICategoryService categoryService, IOrderService orderService)
        {
            _customerService = customerService;
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
            _orderService = orderService;

            //fake data
            _mockBookRepository = new Mock<IBookRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _bookService = new BookService(_mockBookRepository.Object, _mockUnitOfWork.Object);
            _bookViewModel = Commons.GetBookViewModels();
            _books = Commons.GetBooks();

            _mockOrderDetailRepository = new Mock<IOrderDetailRepository>();
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _orderService = new OrderService(_mockOrderRepository.Object, _mockUnitOfWork.Object, _mockOrderDetailRepository.Object);
            _orderViewModels = Commons.OrderViewModels();

        }

        /// <summary>
        /// handle summary
        /// </summary>
        /// <param name="sender">param of action get from request</param>
        /// <param name="type">kind of service you want operator</param>
        /// <param name="act">action of service you want call</param>
        /// <returns></returns>
        public object Handle(object sender, string type, string act)
        {
            Log.Info("Begin: Handle");
            try
            {
                switch (type)
                {
                    case Constants.StatusTypes.Customer:
                        return CustomerActions(sender, act);
                    case Constants.StatusTypes.Book:
                        return BookActions(sender, act);
                    case Constants.StatusTypes.Category:
                        return CategoryActions(sender, act);
                    case Constants.StatusTypes.Author:
                        return AuthorActions(sender, act);
                    case Constants.StatusTypes.Order:
                        return OrderActions(sender, act);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Log.Error("Handle Exception: " + e.Message);
                return e.Message;
            }

            Log.Info("End: Handle");
            return null;
        }

        #region CallActions

        private object OrderActions(object sender, string act)
        {
            _mockOrderRepository.Setup(m => m.GetAllOrders()).Returns(_orderViewModels);
            switch (act)
            {
                case Constants.ActionTypes.GetAll:
                    return _orderService.GetAllOrder();

            }

            return null;
        }

        /// <summary>
        /// call services of category
        /// </summary>
        /// <param name="sender">param of action</param>
        /// <param name="act">action of category</param>
        /// <returns></returns>
        private object CategoryActions(object sender, string act)
        {
            switch (act)
            {
                case Constants.ActionTypes.GetAll:
                    return _categoryService.GetAll();

            }
            return null;
        }

        /// <summary>
        ///  call services of book
        /// </summary>
        /// <param name="sender">param of action</param>
        /// <param name="act">action of book</param>
        /// <returns></returns>
        private object BookActions(object sender, string act)
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

            // arrange
            _mockBookRepository.Setup(m => m.GetAllBooks()).Returns(_bookViewModel);

            switch (act)
            {
                case Constants.ActionTypes.GetAll:
                    return _bookService.GetAll();
                case Constants.ActionTypes.GetByAlias:
                    return _bookService.GetByAlias(sender.ToString());
                case Constants.ActionTypes.GetAllBooks:
                    return _bookService.GetAllBooks();


            }
            return null;
        }
        /// <summary>
        /// call services of author
        /// </summary>
        /// <param name="sender">param of action</param>
        /// <param name="act">action of author</param>
        /// <returns></returns>
        private object AuthorActions(object sender, string act)
        {

            switch (act)
            {
                case Constants.ActionTypes.GetAll:
                    return _authorService.GetAll();
                case Constants.ActionTypes.GetByAlias:
                    return _authorService.GetByAlias(sender.ToString());

            }
            return null;
        }
        /// <summary>
        /// call services of customer
        /// </summary>
        /// <param name="sender">param of action</param>
        /// <param name="act">action of customer</param>
        /// <returns></returns>
        private object CustomerActions(object sender, string act)
        {
            switch (act)
            {
                case Constants.ActionTypes.GetAll:
                    return _customerService.GetAll();
                case Constants.ActionTypes.GetByAlias:
                    return _customerService.GetByAlias(sender.ToString());
                case Constants.ActionTypes.Add:
                    _customerService.Add(sender as Customer);
                    return null;
                case Constants.ActionTypes.SaveChanges:
                    _customerService.SaveChanges();
                    return null;

            }

            return null;
        }

        #endregion


    }
}
