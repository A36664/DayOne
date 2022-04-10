using BookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IBookService
    {
        Task<List<BookViewModel>> GetListBookByPaging(int page, int pageSize);
        
        Task<BookViewModel>GetBookById(int id);
        Task<int> Delete(int ProductId);

        Task<BookViewModel> Update(BookViewModel request);
    }
}
