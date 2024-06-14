using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.NewsArticleService;
using System.Text.Json;

namespace NguyenQuocThienRazorPages.Pages.NewsArticleRazorPages
{
    public class AdminReportStatisticModel : SessionProgress
    {
        private readonly INewsArticleService _newsArticleService;
        public AdminReportStatisticModel()
        {
            _newsArticleService = new NewsArticleService();
            RoleDiv = 0;
        }
        [BindProperty(SupportsGet = true)]
        public IList<NewsArticle> NewsArticle { get; set; } = new List<NewsArticle>();
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public async Task OnGetAsync()
        {
            if (GrantPer)
            {
                var Session = HttpContext.Session.GetString("UserSession");
                SystemAccount getUser = JsonSerializer.Deserialize<SystemAccount>(Session);
                NewsArticle = await _newsArticleService.GetNewsArticlesByDateRange(StartDate, EndDate);
            }
        }
    }
}
