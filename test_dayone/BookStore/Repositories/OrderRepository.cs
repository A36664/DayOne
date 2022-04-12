using BookStore.Data.Entities;
using BookStore.Infrastructure;

namespace BookStore.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }



    }
}
