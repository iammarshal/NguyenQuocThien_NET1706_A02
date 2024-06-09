using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Services.NewsArticleService;
using Services.CategoryService;
using Services.SystemAccountService;

namespace NguyenQuocThienRazorPages.Pages.NewsArticleRazorPages
{
    public class EditModel : SessionProgress
    {
        private readonly INewsArticleService _newsArticleService;
        private readonly ICategoryService _categoryService;
        private readonly ISystemAccountService _systemAccountService;
        private List<Category> _listCategory = new List<Category>();
        private List<SystemAccount> _listSystemAccount = new List<SystemAccount>();
        public EditModel()
        {
            _newsArticleService = new NewsArticleService();
            _categoryService = new CategoryService();
            _systemAccountService = new SystemAccountService();
            RoleDiv = 1;
        }

        [BindProperty]
        public NewsArticle NewsArticle { get; set; } = default!;
        public SelectList Categories { get; set; }
        public SelectList Users { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if(GrantPer)
            {
                if (id == null)
                {
                    return NotFound();
                }
                NewsArticle = await _newsArticleService.GetNewsArticleById(id);
                _listCategory = _categoryService.GetCategories();
                _listSystemAccount = _systemAccountService.GetSystemAccount();
                Categories = new SelectList(_listCategory, "CategoryId", "CategoryName", NewsArticle.CategoryId);
                Users = new SelectList(_listSystemAccount, "AccountId", "AccountName", NewsArticle.CreatedById);
                if (NewsArticle == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (GrantPer)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                try
                {
                    _newsArticleService.UpdateNewsArticle(NewsArticle);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_newsArticleService.GetNewsArticleById(NewsArticle.NewsArticleId) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return RedirectToPage("./Index");
        }
    }
}
