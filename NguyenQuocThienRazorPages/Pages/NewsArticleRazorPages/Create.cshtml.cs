using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using DataAcessLayer;
using Services.NewsArticleService;
using Services.CategoryService;
using Services.SystemAccountService;

namespace NguyenQuocThienRazorPages.Pages.NewsArticleRazorPages
{
    public class CreateModel : PageModel
    {
        private readonly INewsArticleService _newsArticleService;
        private readonly ICategoryService _categoryService;
        private readonly ISystemAccountService _systemAccountService;
        private List<Category> _listCategory = new List<Category>();
        private List<SystemAccount> _listSystemAccount = new List<SystemAccount>();

        public CreateModel()
        {
            _newsArticleService = new NewsArticleService();
            _categoryService = new CategoryService();
            _systemAccountService = new SystemAccountService();
        }
        [BindProperty]
        public NewsArticle NewsArticle { get; set; } = default!;
        public SelectList Categories { get; set; }
        public SelectList Users { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            NewsArticle = new NewsArticle(); 

            _listCategory = _categoryService.GetCategories();
            _listSystemAccount = _systemAccountService.GetSystemAccount();

            Categories = new SelectList(_listCategory, "CategoryId", "CategoryName", NewsArticle.CategoryId);
            Users = new SelectList(_listSystemAccount, "AccountId", "AccountName", NewsArticle.CreatedById);

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _newsArticleService.AddNewsArticle(NewsArticle);      

            return RedirectToPage("./Index");
        }
    }
}
