using BookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Services
{
    public interface IAuthorService:IBaseService<Author>
    {
        Author GetByAlias(string alias);
    }
}
