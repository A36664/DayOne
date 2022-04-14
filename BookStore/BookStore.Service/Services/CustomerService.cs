using BookStore.Infrastructure;
using BookStore.Model.Entities;
using BookStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork=unitOfWork;
        }

        public void Add(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public void Delete(int id)
        {
            var customer = _customerRepository.GetSingleById(id);
            _customerRepository.Delete(customer);
        }

        public Customer Get(int id)
        {
            return _customerRepository.GetSingleById(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetByAlias(string alias)
        {
            return _customerRepository.GetSingleByCondition(x=>x.Name == alias);

        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Customer customer)
        {
            _customerRepository.Update(customer);
        }
    }
}
