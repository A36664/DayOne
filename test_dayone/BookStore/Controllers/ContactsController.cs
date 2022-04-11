using BookStore.Applications;
using BookStore.Data.EF;
using BookStore.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class ContactsController : Controller
    {
        private readonly BookStoreContext _context;
        public ContactsController(BookStoreContext context)
        {
            _context = context;
            // dùng chung mọt instance context 
            UnitOfWork unitOfWork = new UnitOfWork(_context);

            unitOfWork.orderRepository.Add(new Order() { });

            unitOfWork.CustomerRepository.Add(new Customer() { });

            unitOfWork.Save();
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
