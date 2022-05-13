using Domain;
using Domain.Cart;
using Domain.Marketplace;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public interface IDbContext
{
    DbSet<AppUser> Users { get; set; }
    DbSet<Dish> Dishes { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<ProductShopPrice> Prices { get; set; }
    DbSet<CartProduct> CartProducts { get; set; }
    Task<int> SaveChangesAsync(CancellationToken token = default);
}
