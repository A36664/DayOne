using BookStore.Data.EF;
using BookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookStore.Helpers;
using BookStore.Data.Entities;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly BookStoreContext _context;

        public BookService(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> Delete(int bookId)
        {


            var book = await _context.Books.FindAsync(bookId);

            if (book != null)
            {
                _context.Books.Remove(book);
            }


            return await _context.SaveChangesAsync();
        }
        public async Task<BookViewModel> GetBookById(int id)
        {
            var book = await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            var author = await _context.Authors.Where(x => x.Id == book.AuthorId).FirstOrDefaultAsync();
            var categories = await (from bic in _context.BookInCategories
                                    where bic.BookId == id
                                    join ct in _context.Categories on bic.CategoryId equals ct.Id
                                    select ct.Name).ToListAsync();

            var result = new BookViewModel()
            {
                AuthorName = author.Name,
                CategoryName = categories.ListToString(),
                Id = book.Id,
                Name = book.Name,
                OriginalPrice = book.Price,
                Price = book.Price,
                Stock = book.Stock,
            };

            return result;
        }

        public async Task<List<BookViewModel>> GetListBookByPaging(int page, int pageSize)
        {
            var query = from b in _context.Books
                        join bc in _context.BookInCategories on b.Id equals bc.BookId
                        join ct in _context.Categories on bc.CategoryId equals ct.Id
                        join aut in _context.Authors on b.Id equals aut.Id
                        select new { b, bc, ct, aut };
            int totalRow = await query.CountAsync();
            var data = await query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new BookViewModel()
            {
                Id = x.b.Id,
                Name = x.b.Name,
                OriginalPrice = x.b.OriginalPrice,
                Price = x.b.Price,
                Stock = x.b.Stock,
                AuthorName = x.aut.Name,
                CategoryName = x.ct.Name,

            }).ToListAsync();
            return data;
        }

        public async Task<BookViewModel> Update(BookViewModel request)
        {
            var book = await _context.Books.FindAsync(request.Id);
            if (book != null)
            {
                book.Price = request.Price;
                book.OriginalPrice = request.OriginalPrice;
                book.Stock = request.Stock;
                book.Name = request.Name;


            }

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return request;
        }
    }
}
