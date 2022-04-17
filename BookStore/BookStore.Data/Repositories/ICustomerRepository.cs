using System.Collections.Generic;
using BookStore.Data.Infrastructure;
using BookStore.Model.Entities;

namespace BookStore.Data.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        List<Customer> GetByAlias(string alias);
    }
}
