namespace Web.Areas.Cart;

public class CartVM
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUri { get; set; } = string.Empty;
    public int Weight { get; set; }
    public decimal Price { get; set; }
    public string ShopName { get; set; } = string.Empty;
    public uint Count { get; set; }

}
