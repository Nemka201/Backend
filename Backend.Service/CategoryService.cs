using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitWork;

namespace Backend.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }
        public void AddCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.Save();
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public List<Category> GetAllCategories()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _unitOfWork.CategoryRepository.GetAllAsync();
        }

        public Category GetCategory(int id)
        {
            return _unitOfWork.CategoryRepository.FindById(id);
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _unitOfWork.CategoryRepository.FindByIdAsync(id);
        }

        public void RemoveCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Delete(category);
            _unitOfWork.Save();
        }

        public async Task RemoveCategoryAsync(Category category)
        {
            await _unitOfWork.CategoryRepository.DeleteAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public void UpdateCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Edit(category);
            _unitOfWork.Save();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _unitOfWork.CategoryRepository.Edit(category);
            await _unitOfWork.SaveAsync();
        }
    }
}
