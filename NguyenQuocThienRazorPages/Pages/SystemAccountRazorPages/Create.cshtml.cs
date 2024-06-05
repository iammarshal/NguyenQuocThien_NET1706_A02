using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Services.SystemAccountService;

namespace NguyenQuocThienRazorPages.Pages.SystemAccountRazorPages
{
    public class CreateModel : PageModel
    {
        private readonly SystemAccountService _systemAccountService;

        public CreateModel()
        {
            _systemAccountService = new SystemAccountService();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SystemAccount SystemAccount { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingSystemAccountID = _systemAccountService.GetSystemAccountById(SystemAccount.AccountId);
            if (existingSystemAccountID != null)
            {
                ModelState.AddModelError(string.Empty, "Id is already exist");
                return Page();
            }
            
            var existingSystemAccountEmail = _systemAccountService.GetSystemAccountByEmail(SystemAccount.AccountEmail);
            if (existingSystemAccountEmail != null)
            {
                ModelState.AddModelError(string.Empty, "Email is already exist");
                return Page();
            }
            _systemAccountService.AddSystemAccount(SystemAccount);

            return RedirectToPage("./SystemAccountIndex");
        }
    }
}
