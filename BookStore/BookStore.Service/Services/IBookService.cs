using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Services
{
    public interface IBookService:IBaseService<Book>
    {
        List<BookViewModel> GetAllBooks();
        BookViewModel GetByAlias(string alias);
    }
}
