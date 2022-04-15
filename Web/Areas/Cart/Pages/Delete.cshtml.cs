using System.Data;
using Domain.Cart;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.Cart.Pages;

public class DeleteProduct : PageModel
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IDbContext _context;

    public DeleteProduct(UserManager<AppUser> userManager, IDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task OnPost(int id, string shopName)
    {
        var products = (await _userManager.GetUserAsync(User)).CartProducts;
        var containedProduct = products.Find(p => p.ProductId == id && p.ShopName == shopName)!;

        containedProduct.Count--;
        if (containedProduct.Count == 0)
        {
            products.Remove(containedProduct);
        }

        await _context.SaveChangesAsync();
    }
}
