using BookStore.Data.Infrastructure;
using BookStore.Model.Entities;
using System.Collections.Generic;

namespace BookStore.Data.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        List<Author> GetByAlias(string alias);
    }
}
