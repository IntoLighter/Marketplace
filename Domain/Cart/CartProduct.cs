using Domain.Marketplace;

namespace Domain.Cart;

public class CartProduct
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public decimal Price { get; set; }
    public string ShopName { get; set; } = string.Empty;
    public uint Count { get; set; }
}
