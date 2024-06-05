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
    public class DetailsModel : PageModel
    {
        private readonly NewsArticleService _newsArticleService;

        public DetailsModel()
        {
            _newsArticleService = new NewsArticleService();
        }

        public NewsArticle NewsArticle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
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
            return Page();
        }
    }
}
