using System.Collections.Generic;
using System.Linq;
using BookStore.Data.Infrastructure;
using BookStore.Model.Entities;

namespace BookStore.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// Get customer by alias
        /// </summary>
        /// <param name="alias">alias exam is name of customer</param>
        /// <returns></returns>
        public List<Customer> GetByAlias(string alias)
        {
            return DbContext.Customers.Where(x => x.Name.Contains(alias)).ToList();
        }
    }
}
