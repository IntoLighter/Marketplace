using Domain.Cart;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class AppUser : IdentityUser
{
    public List<CartProduct> CartProducts { get; set; } = new();
    public string? ImageUri { get; set; }
}
