using BookStore.Data.Infrastructure;
using BookStore.Model.Entities;
using System.Collections.Generic;

namespace BookStore.Data.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        List<Customer> GetByAlias(string alias);
    }
}
