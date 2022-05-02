using Domain.Marketplace;

namespace Application;

public interface IGetIItemInformation
{
    Dictionary<string, decimal> GetPricesForShop(IItem item);
}