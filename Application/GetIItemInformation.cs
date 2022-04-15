using Domain.Marketplace;
using Infrastructure.Persistence;

namespace Application;

public class GetIItemInformation : IGetIItemInformation
{
    private readonly IDbContext _context;

    public GetIItemInformation(IDbContext context)
    {
        _context = context;
    }

    public Dictionary<string, decimal> GetPricesForShop(IItem item)
    {
        return Enum.GetValues(typeof(Shop)).Cast<Shop>()
            .ToDictionary(shop => shop.ToString(), shop => _context.Prices.Find(item.Id, shop)!.Price);
    }
}
