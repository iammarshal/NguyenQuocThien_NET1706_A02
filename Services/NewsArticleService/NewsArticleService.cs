using BusinessObject;
using DataAcessLayer;
using Repositories.NewsArticleRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.NewsArticleService
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly INewsArticleRepo _newsArticleRepo;
        public NewsArticleService()
        {

            _newsArticleRepo = new NewsArticleRepo();

        }

        public async Task AddNewsArticle(NewsArticle newsArticle)
        {
           await _newsArticleRepo.AddNewsArticle(newsArticle);
        }

        public async Task DeleteNewsArticle(NewsArticle newsArticle)
        {
            await _newsArticleRepo.DeleteNewsArticle(newsArticle);
        }

        public List<NewsArticle> GetNewsArticle()
        {
            return _newsArticleRepo.GetNewsArticle();
        }

        public Task<NewsArticle> GetNewsArticleById(string id) => _newsArticleRepo.GetNewsArticleById(id);
        

        public void UpdateNewsArticle(NewsArticle newsArticle)
        {
            _newsArticleRepo.UpdateNewsArticle(newsArticle);
        }

        public List<NewsArticle> GetNewsArticlesByCreatedId(short Id)
        {
            return _newsArticleRepo.GetNewsArticlesByCreatedId(Id);
        }
        public async Task<List<NewsArticle>> GetNewsArticlesByDateRange(DateTime? startDate, DateTime? endDate)
        {
            return await _newsArticleRepo.GetNewsArticlesByDateRange(startDate, endDate);
        }
    }
}
