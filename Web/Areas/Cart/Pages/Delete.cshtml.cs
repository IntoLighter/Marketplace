using Infrastructure.Identity;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.Cart.Pages;

public class DeleteProduct : PageModel
{
    private readonly IDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public DeleteProduct(UserManager<AppUser> userManager, IDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task OnPost(int id, string shopName)
    {
        var products = (await _userManager.GetUserAsync(User)).CartProducts;
        var containedProduct = products.Find(p => p.Id == id && p.ShopName == shopName)!;

        containedProduct.Count--;
        if (containedProduct.Count == 0) products.Remove(containedProduct);

        await _context.SaveChangesAsync();
    }
}