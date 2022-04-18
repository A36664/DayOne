using BookStore.Data.Infrastructure;
using BookStore.Model.Entities;

namespace BookStore.Data.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
