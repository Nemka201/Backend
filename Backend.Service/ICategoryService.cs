using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service
{
    public interface ICategoryService
    {
        public Category GetCategory(int id);
        public List<Category> GetAllCategories();
        public void AddCategory(Category category);
        public void RemoveCategory(Category category);
        public void UpdateCategory(Category category);
        public Task<Category> GetCategoryAsync(int id);
        public Task<List<Category>> GetAllCategoriesAsync();
        public Task AddCategoryAsync(Category category);
        public Task RemoveCategoryAsync(Category category);
        public Task UpdateCategoryAsync(Category category);
    }
}
