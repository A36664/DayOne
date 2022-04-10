using BookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerViewModel>> GetCustomerPaging(int page, int pageSize);
        Task<CustomerViewModel> GetCustomerById(int id);
        Task<int> Delete(int ProductId);

        Task<CustomerViewModel> Update(CustomerViewModel request);
    }
}
