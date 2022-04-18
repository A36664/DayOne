using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using BookStore.Model.Entities;
using BookStore.Shared.Helpers;
using log4net;
using System.Collections.Generic;
using BookStore.Data.EF;
using System.Data.Entity;
using System.Linq;
using Moq;

namespace BookStore.Service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private static readonly ILog Log = LogHelper.GetLogger();
        public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Add an author
        /// </summary>
        /// <param name="author"></param>
        public Author Add(Author author)
        {
            Log.Info("Begin: Add");
            var result = _authorRepository.Add(author);
            Log.Info("End: Add");
            return result;
        }
        /// <summary>
        /// Delete an author by id
        /// </summary>
        /// <param name="id">id of author</param>
        public void Delete(int id)
        {
            Log.Info("Begin: Delete");
            var author = _authorRepository.GetSingleById(id);
            if (author != null)
                _authorRepository.Delete(author);
            Log.Info("End: Delete");
        }
        /// <summary>
        /// get an author by id
        /// </summary>
        /// <param name="id">id of author</param>
        /// <returns></returns>
        public Author Get(int id)
        {
            Log.Info("Begin: Get");
            var author = _authorRepository.GetSingleById(id);
            Log.Info("End: Get");
            return author;
        }
        /// <summary>
        /// Get all authors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Author> GetAll()
        {
            Log.Info("Begin: GetAll");
            var authors = _authorRepository.GetAll();
            Log.Info("End: GetAll");
            return authors;
        }
        /// <summary>
        /// Get author by alias
        /// </summary>
        /// <param name="alias">alias is name of author</param>
        /// <returns></returns>
        public List<Author> GetByAlias(string alias)
        {
         
            Log.Info("Begin: GetByAlias");
            var authors = _authorRepository.GetByAlias(alias);
            Log.Info("End: GetByAlias");
            return authors;
        }
        /// <summary>
        /// SaveChanges of table author
        /// </summary>
        public void SaveChanges()
        {
            Log.Info("Begin: SaveChanges");
            _unitOfWork.Commit();
            Log.Info("End: SaveChanges");
        }
        /// <summary>
        /// Update an author
        /// </summary>
        /// <param name="author"></param>
        public void Update(Author author)
        {
            Log.Info("Begin: Update");
            _authorRepository.Update(author);
            Log.Info("End: Update");
        }
    }
}
