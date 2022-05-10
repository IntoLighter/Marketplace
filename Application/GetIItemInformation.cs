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

    public Dictionary<string, decimal> GetPricesByShop(IItem item)
    {
        if (item is Dish dish)
        {
            var prices = Enum.GetValues(typeof(Shop)).Cast<Shop>()
                .ToDictionary(shop => shop.ToString(), _ => (decimal)0);

            foreach (var productPrices in dish.Products.Select(product => GetPricesForProduct(product.Product)))
            {
                foreach (var (shop, price) in productPrices)
                {
                    prices[shop] += price;
                }
            }

            return prices;
        }

        return GetPricesForProduct((Product)item);
    }

    private Dictionary<string, decimal> GetPricesForProduct(Product product)
    {
        return Enum.GetValues(typeof(Shop)).Cast<Shop>()
            .ToDictionary(shop => shop.ToString(), shop => _context.Prices.Find(product.Id, shop)!.Price);
    }
}
