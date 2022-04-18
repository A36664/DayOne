using BookStore.Model.Entities;
using System.Collections.Generic;

namespace BookStore.Service.Services
{
    public interface IAuthorService : IBaseService<Author>
    {
        List<Author> GetByAlias(string alias);
    }
}
