using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Services.CategoryService;

namespace NguyenQuocThienRazorPages.Pages.CategoryRazorPages
{
    public class DeleteModel : SessionProgress
    {
        private readonly ICategoryService _categoryService;

        public DeleteModel()
        {
            _categoryService = new CategoryService();
            RoleDiv = 1;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (GrantPer)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var category = await _categoryService.GetCategoryById(id);

                if (category == null)
                {
                    return NotFound();
                }
                else
                {
                    Category = category;
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (GrantPer) {
                if (id == null)
                {
                    return NotFound();
                }

                var category = await _categoryService.GetCategoryById(id);
                if (category != null)
                {
                    Category = category;
                    await _categoryService.DeleteCategory(Category);
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
