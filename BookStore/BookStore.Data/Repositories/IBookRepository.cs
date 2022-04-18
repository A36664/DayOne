using BookStore.Data.Infrastructure;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using System.Collections.Generic;

namespace BookStore.Data.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        List<BookViewModel> GetAllBooks();
        List<BookViewModel> GetByAlias(string alias);



    }
}
