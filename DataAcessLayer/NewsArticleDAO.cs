using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class NewsArticleDAO
    {
        public static List<NewsArticle> GetNewsArticles()
        {
            var listNewsArticles = new List<NewsArticle>();
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    listNewsArticles = _context.NewsArticles
                        .AsNoTracking().Include(c => c.Category).Include(c => c.Tags).Include(c => c.CreatedBy)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listNewsArticles;
        }
        public static async Task AddNewsArticle(NewsArticle newsArticle)
        {
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    _context.NewsArticles.Add(newsArticle);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateNewsArticle(NewsArticle newsArticle)
        {
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    //_context.NewsArticles.Include(c => c.Category).Include(c => c.CreatedBy).Include(c => c.Tags).ToList();
                    _context.NewsArticles.Update(newsArticle);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static async Task DeleteNewsArticle(NewsArticle newsArticle)
        {
            try
            {
                using (var _context = new FunewsManagementDbContext())
                {
                    var newsArticleInDb = await _context.NewsArticles
                        .Include(na => na.Tags)
                        .SingleOrDefaultAsync(na => na.NewsArticleId == newsArticle.NewsArticleId);

                    if (newsArticleInDb != null)
                    {
                        newsArticleInDb.Tags.Clear();
                        _context.NewsArticles.Remove(newsArticleInDb);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static async Task<NewsArticle> GetNewsArticleById(string id)
        {
            using (var _context = new FunewsManagementDbContext())
            {
                return await _context.NewsArticles
                    .Include(c => c.Category)
                    .Include(c => c.Tags)
                    .Include(c => c.CreatedBy)
                    .SingleOrDefaultAsync(c => c.NewsArticleId == id);
            }
        }

        public static List<NewsArticle> GetNewsArticlesByCreatedId(short Id)
        {
            using (var _context = new FunewsManagementDbContext())
            {
                return _context.NewsArticles
                    .Include(n => n.Category)
                    .Include(n => n.Tags)
                    .Include(n => n.CreatedBy)
                    .Where(n => n.NewsStatus == true && n.CreatedById == Id)
                    .ToList();
            }
        }
        public static async Task<List<NewsArticle>> GetNewsArticlesByDateRange(DateTime? startDate, DateTime? endDate)
        {
            using (var _context = new FunewsManagementDbContext())
            {
                var query = _context.NewsArticles.AsQueryable();

                if (startDate.HasValue)
                {
                    query = query.Where(n => n.CreatedDate >= startDate || n.ModifiedDate >= startDate);
                }

                if (endDate.HasValue)
                {
                    query = query.Where(n => n.CreatedDate <= endDate || n.ModifiedDate <= endDate);
                }

                return await query
                    .Include(c => c.Category)
                    .Include(c => c.Tags)
                    .Include(c => c.CreatedBy)
                    .ToListAsync();
            }
        }
    }
}
