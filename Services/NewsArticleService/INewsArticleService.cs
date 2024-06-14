using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.NewsArticleService
{
    public interface INewsArticleService
    {
        List<NewsArticle> GetNewsArticle();
        Task AddNewsArticle(NewsArticle newsArticle);
        void UpdateNewsArticle(NewsArticle newsArticle);
        Task DeleteNewsArticle(NewsArticle newsArticle);
        Task<NewsArticle> GetNewsArticleById(string id);
        List<NewsArticle> GetNewsArticlesByCreatedId(short Id);
        Task<List<NewsArticle>> GetNewsArticlesByDateRange(DateTime? startDate, DateTime? endDate);
    }
}
