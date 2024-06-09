using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Services.NewsArticleService;

namespace NguyenQuocThienRazorPages.Pages.NewsArticleRazorPages
{
    public class IndexModel : SessionProgress
    {
        private readonly NewsArticleService _newsArticleService;

        public IndexModel()
        {
            _newsArticleService = new NewsArticleService();
            RoleDiv = 1;
        }

        public IList<NewsArticle> NewsArticle { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (GrantPer)
            {
                NewsArticle = _newsArticleService.GetNewsArticle();
            }
        }
    }
}
