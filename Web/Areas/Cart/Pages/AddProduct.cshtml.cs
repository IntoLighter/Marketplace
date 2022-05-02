using Domain.Cart;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.Cart.Pages;

public class AddProduct : PageModel
{
    private readonly IDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public AddProduct(UserManager<AppUser> userManager, IDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task OnGet(CartProduct product)
    {
        var products = (await _userManager.GetUserAsync(User)).CartProducts;
        var containedProduct = products.Find(p => p.ProductId == product.ProductId
                                                  && p.ShopName == product.ShopName);
        if (containedProduct == null)
            products.Add(product);
        else
            containedProduct.Count += product.Count;

        await _context.SaveChangesAsync();
    }
}