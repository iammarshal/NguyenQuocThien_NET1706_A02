﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CategoryRepo
{
    public interface ICategoryRepo
    {
        List<Category> GetCategories();
        Task AddCategory(Category category);
        void UpdateCategory(Category category);
        Task DeleteCategory(Category category);
        Task<Category> GetCategoryById(int id);
    }
}
