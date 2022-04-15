using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookStore.Model.Entities;
using BookStore.Service.Services;
using BookStore.Shared;

namespace BookStore.Service
{
    public class MainHandler:IMainHandler
    {
       
        private readonly ICustomerService _customerService;
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private  readonly  ICategoryService _categoryService;
        public MainHandler(ICustomerService customerService,IBookService bookService,IAuthorService authorService,ICategoryService categoryService)
        {
            _customerService = customerService;
            _bookService = bookService;
            _authorService= authorService;
            _categoryService= categoryService;
        }

      /// <summary>
      /// handle summary
      /// </summary>
      /// <param name="sender">param of action get from request</param>
      /// <param name="type">kind of service you want operator</param>
      /// <param name="act">action of service you want call</param>
      /// <returns></returns>
        public object Handle(object sender, string type,string act)
        {
            switch (type)
            {
                case Constants.StatusTypes.Customer:
                    return CustomerActions(sender,act);
                case Constants.StatusTypes.Book:
                    return BookActions(sender, act);
                case Constants.StatusTypes.Category:
                    return CategoryActions(sender, act);
                case Constants.StatusTypes.Author:
                    return AuthorActions(sender, act);

            }

            return null;
        }

        #region CallActions
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
            switch (act)
            {
                case Constants.ActionTypes.GetAll:
                    return _bookService.GetAll();
                case Constants.ActionTypes.GetById:
                    return _customerService.GetByAlias(sender.ToString());

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
                case Constants.ActionTypes.GetById:
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
                case Constants.ActionTypes.GetById:
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
