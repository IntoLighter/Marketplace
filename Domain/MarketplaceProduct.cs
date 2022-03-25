namespace Domain;

public class MarketplaceProduct : IMarketplaceItem
{
    public string Name { get; set; }
    public DishCategory Category { get; set; }
    public string Description { get; set; }
}
