using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace NguyenQuocThienRazorPages.Pages.CategoryRazorPages
{
    public class EditModel : SessionProgress
    {
        private readonly DataAcessLayer.FunewsManagementDbContext _context;

        public EditModel(DataAcessLayer.FunewsManagementDbContext context)
        {
            _context = context;
            RoleDiv = 1;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if(GrantPer)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);
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

                _context.Attach(Category).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(Category.CategoryId))
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

        private bool CategoryExists(short id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
