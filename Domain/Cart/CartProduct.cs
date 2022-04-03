using Domain.Marketplace;

namespace Domain.Cart;

public class CartProduct
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ShopName { get; set; } = string.Empty;
    public uint Count { get; set; }
}
