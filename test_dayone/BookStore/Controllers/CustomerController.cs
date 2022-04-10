using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCustomesPaging()
        {

            var customers = await _customerService.GetCustomerPaging(1, 10);
            if(customers == null)
            {
                return NotFound();

            }
            return View(customers);
        }

        public async Task<IActionResult> Details(int customerId)
        {
            var customer = await _customerService.GetCustomerById(customerId);
            return View(customer);
        }

        public async Task<IActionResult> EditView(int customerId)
        {
            var customer = await _customerService.GetCustomerById(customerId);
            return View(customer);
        }

        public async Task<IActionResult> Edit(CustomerViewModel request)
        {
            var customer = await _customerService.Update(request);
            return Redirect("/");
        }
        public async Task<IActionResult> DeleteView(int customerId)
        {
            var customer = await _customerService.GetCustomerById(customerId);
            return View(customer);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var customer = await _customerService.Delete(Id);
            return Redirect("/"); ;
        }
    }
}
