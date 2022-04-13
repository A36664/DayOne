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
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       

        public List<BookViewModel> GetAllBooks()
        {
            var query = from b in DbContext.Books
                      
                        join ct in DbContext.Categories on b.CategoryId equals ct.Id
                        join aut in DbContext.Authors on b.Id equals aut.Id
                        select new { b, ct, aut };
            int totalRow =  query.Count();
            var results =  query.Select(x => new BookViewModel()
            {
                Id = x.b.Id,
                Name = x.b.Name,
                OriginalPrice = x.b.OriginalPrice,
                Price = x.b.Price,
                Stock = x.b.Stock,
                AuthorName = x.aut.Name,
                CategoryName = x.ct.Name,

            }).ToList();
            return results;
        }
    }
}
