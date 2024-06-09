using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Services.NewsArticleService;

namespace NguyenQuocThienRazorPages.Pages.NewsArticleRazorPages
{
    public class DeleteModel : SessionProgress
    {
        private readonly INewsArticleService _newsArticleService;

        public DeleteModel()
        {
            _newsArticleService = new NewsArticleService();
            RoleDiv = 1;
        }

        [BindProperty]
        public NewsArticle NewsArticle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (GrantPer)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var newsarticle = await _newsArticleService.GetNewsArticleById(id);

                if (newsarticle == null)
                {
                    return NotFound();
                }
                else
                {
                    NewsArticle = newsarticle;
                }
            }  
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if(GrantPer)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var newsarticle = await _newsArticleService.GetNewsArticleById(id);

                if (newsarticle == null)
                {
                    return NotFound();
                }
                else
                {
                    NewsArticle = newsarticle;
                }

                if (newsarticle != null)
                {
                    await _newsArticleService.DeleteNewsArticle(newsarticle);

                }
            }
            return RedirectToPage("./Index");
        }
    }
}
