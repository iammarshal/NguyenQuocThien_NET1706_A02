using BusinessObject;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace NguyenQuocThienRazorPages.Pages
{
    public class SessionProgress : PageModel
    {
        private SystemAccount systemAccount;
        protected int RoleDiv;
        protected bool GrantPer;

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            string json = HttpContext.Session.GetString("UserSession");
            if (!string.IsNullOrEmpty(json))
            {
                systemAccount = JsonSerializer.Deserialize<SystemAccount>(json);
            }
            if (string.IsNullOrEmpty(json))
            {
                context.Result = RedirectToPage("/Login");
                GrantPer = false;
            }
            else if (systemAccount.AccountRole != RoleDiv)
            {
                if (systemAccount.AccountRole == 0)
                {
                    context.Result = RedirectToPage("/AdminPageIndex");
                }
                else
                {
                    context.Result = RedirectToPage("/StaffPageIndex");
                }
                GrantPer = false;
            }
            else
            {
                GrantPer = true;
            }

            base.OnPageHandlerExecuting(context);
        }
    }
}
