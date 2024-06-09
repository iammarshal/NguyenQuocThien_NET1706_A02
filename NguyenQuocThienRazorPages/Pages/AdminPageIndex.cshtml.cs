using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NguyenQuocThienRazorPages.Pages
{
    public class AdminPageIndexModel : SessionProgress
    {
        public AdminPageIndexModel()
        {
            RoleDiv = 0;
        }
        public void OnGet()
        {  
        }
    }
}
