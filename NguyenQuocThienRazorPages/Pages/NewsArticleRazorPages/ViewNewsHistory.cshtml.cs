using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Services.NewsArticleService;

namespace NguyenQuocThienRazorPages.Pages.NewsArticleRazorPages
{
    public class ViewNewsHistoryModel : SessionProgress
    {
        private readonly INewsArticleService _newsArticleService;
        public ViewNewsHistoryModel()
        {
            _newsArticleService = new NewsArticleService();
            RoleDiv = 1;
        }
        [BindProperty] 
        public IList<NewsArticle> NewsArticle { get; set; } = new List<NewsArticle>();

        public async Task OnGetAsync()
        {
            if (GrantPer)
            {
                var Session = HttpContext.Session.GetString("UserSession");
                SystemAccount getUser = JsonSerializer.Deserialize<SystemAccount>(Session);
                NewsArticle = _newsArticleService.GetNewsArticlesByCreatedId(getUser.AccountId);
            }
        }
    }
}
