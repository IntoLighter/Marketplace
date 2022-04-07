using Domain.Marketplace;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public interface IDbContext
{
    DbSet<AppUser> AppUsers { get; set; }
    DbSet<Dish> Dishes { get; set; }
    DbSet<Product> Products { get; set; }
    Task<int> SaveChangesAsync(CancellationToken token = default);
}
