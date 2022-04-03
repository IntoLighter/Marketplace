using Domain.Cart;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.Cart.Pages;

public class DeleteProduct : PageModel
{
    private readonly UserManager<AppUser> _userManager;

    public DeleteProduct(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task OnGet(CartProduct product)
    {
        (await _userManager.GetUserAsync(User)).CartProducts.Remove(product);
    }
}
