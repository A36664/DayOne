using BookStore.Infrastructure;
using BookStore.Models;
using BookStore.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.test
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;
        IUnitOfWork _unitOfWork;
        public CustomerService(ICustomerRepository customerRepository,IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Delete(int CustomerId)
        {
            //var custom= _customerRepository.Delete(CustomerId);
            //if (custom != null)
            //    return ;
        }

        public Task<CustomerViewModel> GetCustomerById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<CustomerViewModel>> GetCustomerPaging(int page, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<CustomerViewModel> Update(CustomerViewModel request)
        {
            throw new System.NotImplementedException();
        }
    }
}
