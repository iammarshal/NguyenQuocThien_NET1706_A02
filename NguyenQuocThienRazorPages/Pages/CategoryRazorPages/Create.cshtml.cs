using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Services.CategoryService;

namespace NguyenQuocThienRazorPages.Pages.CategoryRazorPages
{
    public class CreateModel : SessionProgress
    {
        private readonly ICategoryService _categoryService;

        public CreateModel()
        {
            _categoryService = new CategoryService();
            RoleDiv = 1;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if(GrantPer)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                await _categoryService.AddCategory(Category);
            }
            return RedirectToPage("./Index");
        }
    }
}
