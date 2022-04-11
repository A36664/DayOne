using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            return View();
        }

      
        public async Task<IActionResult> GetBooksPaging()
        {
            var books = await _bookService.GetListBookByPaging(1, 10);

            return View(books);
        }
        [HttpGet("Details")]
        public  async Task<IActionResult> Details(int bookId)
        {
            var book = await _bookService.GetBookById(bookId);  
            return View(book);
        }
        [HttpGet("EditView")]
        public async Task<IActionResult> EditView(int bookId)
        {
            var book = await _bookService.GetBookById(bookId);
            return View(book);
        }

        public async Task<IActionResult> Edit(BookViewModel request)
        {
            var book = await _bookService.Update(request);
            return Redirect("/");
        }
        [HttpGet("DeleteView")]
        public async Task<IActionResult> DeleteView(int bookId)
        {
            var book = await _bookService.GetBookById(bookId);
            return View(book);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int bookId)
        {
            var book = await _bookService.Delete(bookId);
            return Redirect("/"); ;
        }
    }
}
