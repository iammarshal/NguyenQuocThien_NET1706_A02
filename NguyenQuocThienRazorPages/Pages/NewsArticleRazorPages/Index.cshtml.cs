using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using DataAcessLayer;
using Services.NewsArticleService;

namespace NguyenQuocThienRazorPages.Pages.NewsArticleRazorPages
{
    public class IndexModel : PageModel
    {
        private readonly NewsArticleService _newsArticleService;

        public IndexModel()
        {
            _newsArticleService = new NewsArticleService();
        }

        public IList<NewsArticle> NewsArticle { get;set; } = default!;

        public async Task OnGetAsync()
        {
            NewsArticle = _newsArticleService.GetNewsArticle();

        }
    }
}
