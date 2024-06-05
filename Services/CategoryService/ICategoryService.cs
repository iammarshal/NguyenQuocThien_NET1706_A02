﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        Category GetCategoryById(int id);
    }
}
