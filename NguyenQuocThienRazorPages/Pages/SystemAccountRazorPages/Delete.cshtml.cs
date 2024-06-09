using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Services.SystemAccountService;

namespace NguyenQuocThienRazorPages.Pages.SystemAccountRazorPages
{
    public class DeleteModel : SessionProgress
    {
        private readonly SystemAccountService _systemAccountService;

        public DeleteModel()
        {
            _systemAccountService = new SystemAccountService();
            RoleDiv = 0;
        }

        [BindProperty]
        public SystemAccount SystemAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(short id)
        {
            if(GrantPer)
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

        public async Task<IActionResult> OnPostAsync(short id)
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

                if (SystemAccount != null)
                {
                    await _systemAccountService.DeleteNewsArticleAndTags(SystemAccount.NewsArticles.ToList());
                    await _systemAccountService.DeleteSystemAccount(SystemAccount);
                }
            }       
            return RedirectToPage("./SystemAccountIndex");
        }
    }
}
