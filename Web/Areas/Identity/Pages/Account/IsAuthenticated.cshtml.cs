using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.Identity.Pages.Account;

public class IsAuthenticated : PageModel
{
    public bool OnGet()
    {
        return User.Identity?.IsAuthenticated ?? false;
    }
}
