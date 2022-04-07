using Domain.Marketplace;

namespace Application;

public class GetIItemInformation : IGetIItemInformation
{
    public Dictionary<string, int> GetPriceForShop(IItem item)
    {
        foreach (var shop in Arrays.Shops)
        {
        }

        throw new NotImplementedException();
    }
}
