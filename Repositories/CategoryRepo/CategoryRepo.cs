using BusinessObject;
using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CategoryRepo
{
    public class CategoryRepo : ICategoryRepo
    {
        public async Task AddCategory(Category category) => await CategoryDAO.AddCategory(category);
        public async Task DeleteCategory(Category category) => await CategoryDAO.DeleteCategory(category);
        public async Task UpdateCategory(Category category) => await CategoryDAO.UpdateCategory(category);
        public List<Category> GetCategories() => CategoryDAO.GetCategories();
        public async Task<Category> GetCategoryById(int id) => await CategoryDAO.GetCategoryById(id);
    }
}
