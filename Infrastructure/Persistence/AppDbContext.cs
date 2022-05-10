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

    public DbSet<Dish> Dishes { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductShopPrice> Prices { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ProductInDish>().HasKey(e => new { e.ProductId, e.DishId });
        builder.Entity<CartProduct>().HasKey(e => new { ProductId = e.Id, e.ShopName });
        builder.Entity<ProductShopPrice>().HasKey(e => new { e.ProductId, e.Shop });
        builder.Entity<CartProduct>().HasOne(e => e.Product)
            .WithOne().HasForeignKey<CartProduct>(e => e.Id);
    }
}
