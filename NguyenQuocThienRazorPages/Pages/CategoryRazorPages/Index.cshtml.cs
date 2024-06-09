using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Services.CategoryService;

namespace NguyenQuocThienRazorPages.Pages.CategoryRazorPages
{
    public class IndexModel : SessionProgress
    {
        private readonly ICategoryService _categoryService;

        public IndexModel()
        {
            _categoryService = new CategoryService();
            RoleDiv = 1;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if(GrantPer)
            {
                Category = _categoryService.GetCategories();
            }          
        }
    }
}
