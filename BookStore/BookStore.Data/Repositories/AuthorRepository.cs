using BookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Infrastructure;

namespace BookStore.Data.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        /// <summary>
        /// get author by alias
        /// </summary>
        /// <param name="alias">alias is name of author</param>
        /// <returns></returns>
        public List<Author> GetByAlias(string alias)
        {
            return DbContext.Authors.Where(x => x.Name.Contains(alias)).ToList();
        }
    }
}
