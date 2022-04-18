using BookStore.Data.Repositories;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Infrastructure;
using BookStore.Shared.Helpers;
using log4net;
using Microsoft.Extensions.Logging;

namespace BookStore.Service.Services
{
    public class BookService : IBookService
    {


        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private static readonly ILog Log = LogHelper.GetLogger();
        public BookService(IBookRepository bookRepository,IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;

        }
        /// <summary>
        ///  Add a book into table book
        /// </summary>
        /// <param name="book"></param>
        public Book Add(Book book)
        {
            Log.Info("Begin: Add");
          var   result=_bookRepository.Add(book);
            Log.Info("End: Add");
            return result;
        }

       
        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Log.Info("Begin: Delete");
            var book = _bookRepository.GetSingleById(id);
            _bookRepository.Delete(book);
            Log.Info("End: Delete");
        }
        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book Get(int id)
        {
            Log.Info("Begin: Get");
            var book= _bookRepository.GetSingleById(id);
            Log.Info("End: Get");
            return book;
        }
        /// <summary>
        /// Get all books in database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> GetAll()
        {
            Log.Info("Begin: GetAll");
            var result= _bookRepository.GetAll();
          
            Log.Info("Begin: GetAll");
            return result;
        }
        /// <summary>
        ///  Get all books
        /// </summary>
        /// <returns></returns>
        public List<BookViewModel> GetAllBooks()
        {

            Log.Info("Begin: GetAllBooks");
            var books= _bookRepository.GetAllBooks();
            Log.Info("End: GetAllBooks");
            return books;
        }
        /// <summary>
        /// Get book by alias
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BookViewModel> GetByAlias(string alias)
        {
            var books = _bookRepository.GetByAlias(alias);
            if (books.Count > 0)
            {
                return books;
            }
            throw new NullReferenceException();
        }
        /// <summary>
        /// Save changes of book
        /// </summary>
        public void SaveChanges()
        {
            Log.Info("Begin: SaveChanges");
            _unitOfWork.Commit();
            Log.Info("End: SaveChange");
        }
        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="book"></param>
        public void Update(Book book)
        {
            Log.Info("Begin: Update");
            _bookRepository.Update(book);
            Log.Info("End: Update");
        }
    }
}
