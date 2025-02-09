﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Services.SystemAccountService;

namespace NguyenQuocThienRazorPages.Pages.SystemAccountRazorPages
{
    public class EditModel : SessionProgress
    {
        private readonly SystemAccountService _systemAccountService;

        public EditModel()
        {
            _systemAccountService = new SystemAccountService();
            RoleDiv = 0;
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
                var systemaccount = _systemAccountService.GetSystemAccountById(id);
                if (systemaccount == null)
                {
                    return NotFound();
                }
                SystemAccount = systemaccount;
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
            if(GrantPer)
            {
                try
                {
                    _systemAccountService.UpdateSystemAccount(SystemAccount);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_systemAccountService.GetSystemAccountById(SystemAccount.AccountId) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToPage("./SystemAccountIndex");
        }

    }
}
