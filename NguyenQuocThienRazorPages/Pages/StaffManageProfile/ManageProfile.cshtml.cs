using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Services.SystemAccountService;
using System.Text.Json;

namespace NguyenQuocThienRazorPages.Pages.StaffManageProfile
{
    public class ManageProfileModel : SessionProgress
    {
        private readonly SystemAccountService _systemAccountService;


        public ManageProfileModel()
        {
            _systemAccountService = new SystemAccountService();
            RoleDiv = 1;
        }

        [BindProperty]
        public SystemAccount SystemAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(short id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (GrantPer)
            {
                var loggedInUserEmail = HttpContext.Session.GetString("UserSession");
                SystemAccount = JsonSerializer.Deserialize<SystemAccount>(loggedInUserEmail);
                if (SystemAccount == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (GrantPer)
            {
                var loggedInUserEmail = HttpContext.Session.GetString("UserSession");
                var logginUser = JsonSerializer.Deserialize<SystemAccount>(loggedInUserEmail);
                try
                {
                    var Ouser = _systemAccountService.GetSystemAccountById(logginUser.AccountId);
                    if (Ouser == null)
                    {
                        return NotFound();
                    }
                    Ouser.AccountEmail = SystemAccount.AccountEmail;
                    Ouser.AccountPassword = SystemAccount.AccountPassword;
                    Ouser.AccountName = SystemAccount.AccountName;
                    _systemAccountService.UpdateSystemAccount(Ouser);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_systemAccountService.GetSystemAccountById(logginUser.AccountId) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToPage("/StaffPageIndex");
        }
    }
}
