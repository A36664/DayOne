using BookStore.Infrastructure;
using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        List<BookViewModel> GetAllBooks();
     


    }
}
