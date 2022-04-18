using BookStore.Data.Infrastructure;
using BookStore.Model.Entities;

namespace BookStore.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
