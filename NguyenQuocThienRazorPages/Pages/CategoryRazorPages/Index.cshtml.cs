using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using DataAcessLayer;

namespace NguyenQuocThienRazorPages.Pages.CategoryRazorPages
{
    public class IndexModel : PageModel
    {
        private readonly DataAcessLayer.FunewsManagementDbContext _context;

        public IndexModel(DataAcessLayer.FunewsManagementDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
