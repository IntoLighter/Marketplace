namespace Domain;

public class MarketplaceDish : IMarketplaceItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<MarketplaceProduct> Products { get; set; }
}
