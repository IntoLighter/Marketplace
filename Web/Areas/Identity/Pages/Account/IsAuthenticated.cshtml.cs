using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;

namespace Web.Areas.Identity.Pages.Account;

public class IsAuthenticated : PageModel
{
    public IActionResult OnGetAsync()
    {
        return new JsonResult(User.Identity?.IsAuthenticated ?? false);
    }
}
