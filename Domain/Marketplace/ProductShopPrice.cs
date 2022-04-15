namespace Domain.Marketplace;

public class ProductShopPrice
{
    public int ProductId { get; set; }
    public Shop Shop { get; set; }
    public decimal Price { get; set; }
}
