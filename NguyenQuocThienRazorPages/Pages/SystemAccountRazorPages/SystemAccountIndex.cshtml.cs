using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Services.SystemAccountService;

namespace NguyenQuocThienRazorPages.Pages.SystemAccountRazorPages
{
    public class SystemAccountIndexModel : SessionProgress
    {
        private readonly SystemAccountService _systemAccountService;

        public SystemAccountIndexModel()
        {
            _systemAccountService = new SystemAccountService();
            RoleDiv = 0;
        }

        public IList<SystemAccount> SystemAccount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (GrantPer) {
                SystemAccount = _systemAccountService.GetSystemAccount();
            }    
        }
    }
}
