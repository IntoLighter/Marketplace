using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public interface IDbContext
{
    DbSet<AppUser> AppUsers { get; init; }
    Task<int> SaveChangesAsync(CancellationToken token = default);
}
