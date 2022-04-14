using BookStore.Data.Repositories;
using BookStore.Infrastructure;
using BookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Services
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;
        IUnitOfWork _unitOfWork;

        public AuthorService(IAuthorRepository authorRepository,IUnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(Author author)
        {
            _authorRepository.Add(author);
        }

        public void Delete(int id)
        {
           var author = _authorRepository.GetSingleById(id);
            if (author != null)
                _authorRepository.Delete(author);
        }

        public Author Get(int id)
        {
            return _authorRepository.GetSingleById(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public Author GetByAlias(string alias)
        {
            return _authorRepository.GetSingleByCondition(x=>x.Name == alias);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Author author)
        {
            _authorRepository.Update(author);
        }
    }
}
