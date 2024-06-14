using BusinessObject;
using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.NewsArticleRepo
{
    public class NewsArticleRepo : INewsArticleRepo
    {
        public async Task AddNewsArticle(NewsArticle newsArticle) => NewsArticleDAO.AddNewsArticle(newsArticle);
        public async Task DeleteNewsArticle(NewsArticle newsArticle) => await NewsArticleDAO.DeleteNewsArticle(newsArticle);
        public void UpdateNewsArticle(NewsArticle newsArticle) => NewsArticleDAO.UpdateNewsArticle(newsArticle);
        public List<NewsArticle> GetNewsArticle() => NewsArticleDAO.GetNewsArticles();
        public Task<NewsArticle> GetNewsArticleById(string id) => NewsArticleDAO.GetNewsArticleById(id);
        public List<NewsArticle> GetNewsArticlesByCreatedId(short Id) => NewsArticleDAO.GetNewsArticlesByCreatedId(Id);
        public async Task<List<NewsArticle>> GetNewsArticlesByDateRange(DateTime? startDate, DateTime? endDate) => await NewsArticleDAO.GetNewsArticlesByDateRange(startDate, endDate);
    }
}
