using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using System.Collections.Generic;

namespace BookStore.Service.Services
{
    public interface IBookService : IBaseService<Book>
    {
        List<BookViewModel> GetAllBooks();
        List<BookViewModel> GetByAlias(string alias);
    }
}
