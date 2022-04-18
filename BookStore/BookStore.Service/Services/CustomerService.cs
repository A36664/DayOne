using BookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using BookStore.Shared.Helpers;
using log4net;

namespace BookStore.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private static readonly ILog Log = LogHelper.GetLogger();
        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork=unitOfWork;
        }
        /// <summary>
        ///  Add a customer
        /// </summary>
        /// <param name="customer"></param>
        public Customer Add(Customer customer)
        {
            Log.Info("Begin: Add");
          var result=   _customerRepository.Add(customer);
            Log.Info("End: Add");
            return result;
        }
        /// <summary>
        /// Delete a customer by id
        /// </summary>
        /// <param name="id">id of customer want delete</param>
        public void Delete(int id)
        {
            Log.Info("Begin: Delete");
            var customer = _customerRepository.GetSingleById(id);
            _customerRepository.Delete(customer);
            Log.Info("End: Delete");
        }
        /// <summary>
        /// Ge customer by id
        /// </summary>
        /// <param name="id">id of a customer want get</param>
        /// <returns></returns>
        public Customer Get(int id)
        {
            Log.Info("Begin: Get");
            var customer= _customerRepository.GetSingleById(id);
            Log.Info("End: Get");
            return customer;
        }
        /// <summary>
        /// Get all customer in database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetAll()
        {
            Log.Info("Begin: GetAll");
            var customers= _customerRepository.GetAll();
            Log.Info("End: GetAll");
            return customers;
        }
        /// <summary>
        /// Get customer by alias
        /// </summary>
        /// <param name="alias">name of customer</param>
        /// <returns></returns>
        public List<Customer> GetByAlias(string alias)
        {

            Log.Info("Begin: GetByAlias");
            var customers= _customerRepository.GetByAlias(alias);

            Log.Info("End: GetByAlias");

            return customers;
        }
        /// <summary>
        /// SaveChange of customer
        /// </summary>
        public void SaveChanges()
        {
            Log.Info("Begin: SaveChanges");
            _unitOfWork.Commit();
            Log.Info("End: SaveChanges");
        }
        /// <summary>
        /// Update a customer with new info
        /// </summary>
        /// <param name="customer">new info of customer</param>
        public void Update(Customer customer)
        {
            Log.Info("Begin: Update");
            _customerRepository.Update(customer);
            Log.Info("End: Update");
        }
    }
}
