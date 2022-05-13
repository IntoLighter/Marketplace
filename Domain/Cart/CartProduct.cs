using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Marketplace;

namespace Domain.Cart;

public class CartProduct
{
    public int Id { get; set; }
    public Product? Product { get; set; }
    public decimal Price { get; set; }
    public string ShopName { get; set; } = string.Empty;
    public uint Count { get; set; }
    public string UserId { get; set; } = string.Empty;
    public AppUser? User { get; set; }
}
