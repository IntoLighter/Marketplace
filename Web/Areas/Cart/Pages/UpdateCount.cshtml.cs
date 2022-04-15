using Infrastructure.Identity;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.Cart.Pages;

public class UpdateCount : PageModel
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IDbContext _context;

    public UpdateCount(UserManager<AppUser> userManager, IDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task OnPost(int id, string shopName, uint count)
    {
        var products = (await _userManager.GetUserAsync(User)).CartProducts;
        var containedProduct = products.Find(p => p.ProductId == id && p.ShopName == shopName)!;
        containedProduct.Count = count;

        await _context.SaveChangesAsync();
    }
}
