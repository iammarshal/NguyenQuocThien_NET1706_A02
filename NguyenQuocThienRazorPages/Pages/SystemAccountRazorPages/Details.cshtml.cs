using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Services.SystemAccountService;

namespace NguyenQuocThienRazorPages.Pages.SystemAccountRazorPages
{
    public class DetailsModel : PageModel
    {
        private readonly SystemAccountService _systemAccountService;

        public DetailsModel()
        {
            _systemAccountService = new SystemAccountService();
        }

        public SystemAccount SystemAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(short id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemaccount = _systemAccountService.GetSystemAccountById(id);
            if (systemaccount == null)
            {
                return NotFound();
            }
            else
            {
                SystemAccount = systemaccount;
            }
            return Page();
        }
    }
}
