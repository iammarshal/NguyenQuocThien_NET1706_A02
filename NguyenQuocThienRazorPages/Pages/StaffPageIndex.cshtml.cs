using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NguyenQuocThienRazorPages.Pages
{
    public class StaffPageIndexModel : SessionProgress
    {
        public StaffPageIndexModel()
        {
            RoleDiv = 1;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
