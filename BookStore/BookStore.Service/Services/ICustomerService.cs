using BookStore.Model.Entities;
using System.Collections.Generic;

namespace BookStore.Service.Services
{
    public interface ICustomerService : IBaseService<Customer>
    {
        List<Customer> GetByAlias(string alias);
    }
}
