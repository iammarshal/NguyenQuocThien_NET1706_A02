using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            var listCategories = new List<Category>();
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    listCategories = _context.Categories
                        .AsNoTracking()
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listCategories;
        }
        public static void AddCategory(Category category)
        {
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    _context.Categories.Add(category);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateCategory(Category category)
        {
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    _context.Categories.Update(category);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteCategory(Category category)
        {
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    var categoryInDb = _context.Categories
                        .Include(c => c.NewsArticles)
                        .SingleOrDefault(c => c.CategoryId == category.CategoryId);

                    if (categoryInDb == null)
                    {
                        throw new Exception("Category not found");
                    }

                    if (categoryInDb.NewsArticles.Any())
                    {
                        throw new Exception("Cannot delete category. It is associated with one or more News Articles.");
                    }

                    _context.Categories.Remove(categoryInDb);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static Category GetCategoryById(int categoryId)
        {
            using (var _context = new FunewsManagementDbContext())
            {
                return _context.Categories
                    .SingleOrDefault(c => c.CategoryId == categoryId);
            }
        }
    }
}
