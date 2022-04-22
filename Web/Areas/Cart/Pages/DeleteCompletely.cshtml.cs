using Infrastructure.Identity;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Areas.Cart.Pages;

public class DeleteCompletely : PageModel
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IDbContext _context;

    public DeleteCompletely(UserManager<AppUser> userManager, IDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task OnPost(int id, string shopName)
    {
        var products = (await _userManager.GetUserAsync(User)).CartProducts;
        products.Remove(products.Find(p => p.ProductId == id && p.ShopName == shopName)!);
        await _context.SaveChangesAsync();
    }
}