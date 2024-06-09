using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Services.SystemAccountService;

namespace NguyenQuocThienRazorPages.Pages.SystemAccountRazorPages
{
    public class DetailsModel : SessionProgress
    {
        private readonly SystemAccountService _systemAccountService;

        public DetailsModel()
        {
            _systemAccountService = new SystemAccountService();
            RoleDiv = 0;
        }

        public SystemAccount SystemAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(short id)
        {
            if (GrantPer)
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
            }
            return Page();
        }
    }
}
