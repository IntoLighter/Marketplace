using Domain;
using Domain.Cart;
using Domain.Marketplace;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    public DbSet<CartProduct> CartProducts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ProductInDish>().HasKey(e => new { e.ProductId, e.DishId });
        builder.Entity<ProductShopPrice>().HasKey(e => new { e.ProductId, e.Shop });

        var cartProduct = builder.Entity<CartProduct>();
        cartProduct.HasKey(e => new { ProductId = e.Id, e.ShopName, e.UserId });
        cartProduct.HasOne(e => e.Product)
            .WithMany().HasForeignKey(e => e.Id);
    }
}
