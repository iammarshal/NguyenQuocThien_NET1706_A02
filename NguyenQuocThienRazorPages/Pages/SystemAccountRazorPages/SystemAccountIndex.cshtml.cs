using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Services.SystemAccountService;

namespace NguyenQuocThienRazorPages.Pages.SystemAccountRazorPages
{
    public class SystemAccountIndexModel : PageModel
    {
        private readonly SystemAccountService _systemAccountService;

        public SystemAccountIndexModel()
        {
            _systemAccountService = new SystemAccountService();
        }

        public IList<SystemAccount> SystemAccount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SystemAccount =  _systemAccountService.GetSystemAccount();
        }
    }
}
