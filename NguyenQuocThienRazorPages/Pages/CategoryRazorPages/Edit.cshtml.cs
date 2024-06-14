using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Services.CategoryService;

namespace NguyenQuocThienRazorPages.Pages.CategoryRazorPages
{
    public class EditModel : SessionProgress
    {
        private readonly ICategoryService _categoryService;

        public EditModel()
        {
            _categoryService = new CategoryService();
            RoleDiv = 1;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if(GrantPer)
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
                Category = category;
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
                    await _categoryService.UpdateCategory(Category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_categoryService.GetCategoryById(Category.CategoryId) == null)
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
