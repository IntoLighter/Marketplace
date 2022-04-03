using Domain.Cart;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.Cart.Pages;

public class GetProducts : PageModel
{
    private readonly UserManager<AppUser> _userManager;

    public GetProducts(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<CartProduct>?> OnGet()
    {
        return (await _userManager.GetUserAsync(User)).CartProducts;
    }
}
