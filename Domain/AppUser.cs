using Domain.Cart;
using Microsoft.AspNetCore.Identity;

namespace Domain;

public class AppUser : IdentityUser
{
    public List<CartProduct> CartProducts { get; set; } = new();
}
