using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.NewsArticleService;

namespace NguyenQuocThienRazorPages.Pages
{
    public class NewsArticleRazorPageModel : PageModel
    {
        private readonly NewsArticleService _newsArticleService;
        private const int PageSize = 2;

        public NewsArticleRazorPageModel()
        {
            _newsArticleService = new NewsArticleService();     
        }
        [BindProperty]
        public IList<NewsArticle> NewsArticle { get; set; } = default!;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }


        public async Task<IActionResult> OnGetAsync(int? pageIndex)
        {
            CurrentPage = pageIndex ?? 1;

            var totalArticles = _newsArticleService.GetNewsArticle().Count;
            TotalPages = (int)Math.Ceiling((double)totalArticles / PageSize);


            var articles = _newsArticleService.GetNewsArticle()
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            NewsArticle = articles;
            return Page();
        }   
    }
}
