using Domain.Cart;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.Cart.Pages;

public class GetProducts : PageModel
{
    private readonly UserManager<AppUser> _userManager;

    public GetProducts(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> OnGet()
    {
        return new JsonResult((await _userManager.GetUserAsync(User)).CartProducts);
    }
}
