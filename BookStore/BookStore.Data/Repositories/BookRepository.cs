using BookStore.Model.Entities;
using BookStore.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Infrastructure;

namespace BookStore.Data.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       
        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns></returns>
        public List<BookViewModel> GetAllBooks()
        {
            var books =  DbContext.Books.Include(x => x.Author).Include(x => x.Category).Select(x => new BookViewModel()
            {
                AuthorId = x.AuthorId,
                AuthorName = x.Author.Name,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                Name = x.Name,
                OriginalPrice = x.OriginalPrice,
                Id = x.Id,
                Price = x.Price,
                Stock = x.Stock
            }).ToList();

            return books;
        }
        /// <summary>
        /// get all book by alias
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public List<BookViewModel> GetByAlias(string alias)
        {
            var books =  DbContext.Books.Where(x => x.Name.Contains(alias)).Include(x => x.Category)
                .Include(x => x.Author).Select(x => new BookViewModel()
                {
                    AuthorId = x.AuthorId,
                    AuthorName = x.Author.Name,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    Name = x.Name,
                    OriginalPrice = x.OriginalPrice,
                    Id = x.Id,
                    Price = x.Price,
                    Stock = x.Stock
                }).ToList();
            return books;
        }
    }
    
}
