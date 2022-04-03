using Domain.Cart;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.Cart.Pages;

public class AddProduct : PageModel
{
    private readonly UserManager<AppUser> _userManager;

    public AddProduct(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task OnGet(CartProduct product)
    {
        (await _userManager.GetUserAsync(User)).CartProducts.Add(product);
    }
}
