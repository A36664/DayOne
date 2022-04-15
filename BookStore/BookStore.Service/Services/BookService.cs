using BookStore.Data.Repositories;
using BookStore.Infrastructure;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using BookStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Services
{
    public class BookService : IBookService
    {


        private readonly IBookRepository _bookRepository;
        readonly IUnitOfWork _unitOfWork;
        public BookService(IBookRepository bookRepository,IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(Book book)
        {
            _bookRepository.Add(book);
        }

       

        public void Delete(int id)
        {
            var book = _bookRepository.GetSingleById(id);
            _bookRepository.Delete(book);
        }

        public Book Get(int id)
        {
            return _bookRepository.GetSingleById(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public List<BookViewModel> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public BookViewModel GetByAlias(string alias)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Book book)
        {
            _bookRepository.Update(book);
        }
    }
}
