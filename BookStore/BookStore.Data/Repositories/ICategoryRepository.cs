using BookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Infrastructure;

namespace BookStore.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
