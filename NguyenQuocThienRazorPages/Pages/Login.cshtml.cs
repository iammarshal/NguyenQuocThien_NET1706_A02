using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using DataAcessLayer;
using Services.SystemAccountService;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Configuration;
using Microsoft.AspNetCore.Components.Forms;
using System.Text.Json;

namespace NguyenQuocThienRazorPages.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ISystemAccountService _systemAccountService;
        private readonly IConfiguration _configuration;

        public LoginModel()
        {
            _systemAccountService = new SystemAccountService();
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
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
           
            var adEmail = _configuration["AccountEmail:Email"];
            var adPassword = _configuration["AccountPassword:Password"];
            var adRole = _configuration["AccountRole:Role"];
            if(SystemAccount.AccountEmail.Equals(adEmail) && SystemAccount.AccountPassword.Equals(adPassword))
            {
                SystemAccount AdminAccount = new SystemAccount()
                {
                    AccountId = 0,
                    AccountName = "Admin",
                    AccountEmail = adEmail,
                    AccountPassword = adPassword,
                    AccountRole = int.Parse(adRole)
                };
                string json = JsonSerializer.Serialize(AdminAccount);
                HttpContext.Session.SetString("UserSession", json);
                return RedirectToPage("./AdminPageIndex");
            }
            var user = await _systemAccountService.Login(SystemAccount.AccountEmail, SystemAccount.AccountPassword);
            if (user != null)
            {
                if(user.AccountRole == 1)
                {
                    string json = JsonSerializer.Serialize(user);
                    HttpContext.Session.SetString("UserSession", json);
                    return RedirectToPage("./StaffPageIndex");
                }
                    ModelState.AddModelError(string.Empty, "Access Denied");
                return Page();  
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }
    }
    }