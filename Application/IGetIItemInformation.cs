using Domain.Marketplace;

namespace Application;

public interface IGetIItemInformation
{
    Dictionary<string, int> GetPriceForShop(IItem item);
}
