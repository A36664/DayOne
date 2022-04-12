using BookStore.Data.Entities;
using BookStore.Infrastructure;

namespace BookStore.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       

    }
}
