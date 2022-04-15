using Domain.Cart;
using Domain.Marketplace;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : IdentityDbContext<AppUser>, IDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; } = null!;
    public DbSet<Dish> Dishes { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ProductInDish>().HasKey(e => new { e.ProductId, e.DishId });
        builder.Entity<CartProduct>().HasKey(e => new { e.ProductId, e.ShopName });
    }
}
