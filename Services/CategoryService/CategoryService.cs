using BusinessObject;
using Repositories.CategoryRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService()
        {
            if (_categoryRepo == null)
            {
                _categoryRepo = new CategoryRepo();
            }
        }
        public List<Category> GetCategories()
        {
            return _categoryRepo.GetCategories();
        }

        public async Task AddCategory(Category category)
        {
           await _categoryRepo.AddCategory(category);
        }
        public async Task DeleteCategory(Category category)
        {
           await _categoryRepo.DeleteCategory(category);
        }
        public void UpdateCategory(Category category)
        {
            _categoryRepo.UpdateCategory(category);
        }
        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepo.GetCategoryById(id);
        }
    }
}
