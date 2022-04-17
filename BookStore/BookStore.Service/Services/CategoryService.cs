using BookStore.Data.Repositories;
using BookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Infrastructure;
using BookStore.Shared.Helpers;
using log4net;

namespace BookStore.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private static readonly ILog Log = LogHelper.GetLogger();
        public CategoryService(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Add a category
        /// </summary>
        /// <param name="category"></param>
        public void Add(Category category)
        {
            Log.Info("Begin: Add");
            _categoryRepository.Add(category);
            Log.Info("End: Add");
        }
        /// <summary>
        /// Delete a category
        /// </summary>
        /// <param name="id">id of category want delete</param>
        public void Delete(int id)
        {
            Log.Info("Begin: Delete");
            var category = _categoryRepository.GetSingleById(id);
            if (category != null)
                _categoryRepository.Delete(category);
            Log.Info("End: Delete");
        }
        /// <summary>
        /// Get a Category
        /// </summary>
        /// <param name="id">id of a category want get</param>
        /// <returns></returns>
        public Category Get(int id)
        {
            Log.Info("Begin: Get");
            var category= _categoryRepository.GetSingleById(id);
            Log.Info("End: Get");
            return category;
        }
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> GetAll()
        {
            Log.Info("Begin: GetAll");
            var categories= _categoryRepository.GetAll();
            Log.Info("End: GetAll");
            return categories;
        }
        /// <summary>
        /// Save change of table category
        /// </summary>
        public void SaveChanges()
        {
            Log.Info("Begin: SaveChanges");
            _unitOfWork.Commit();
            Log.Info("End: SaveChanges");
        }
        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="category">info of category want update</param>
        public void Update(Category category)
        {
            Log.Info("Begin: Update");
            _categoryRepository.Update(category);
            Log.Info("Begin: Update");
        }
    }
}
