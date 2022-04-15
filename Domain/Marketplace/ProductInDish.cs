namespace Domain.Marketplace;

public class ProductInDish
{
    public int ProductId { get; set; }
    public int DishId { get; set; }
    public Product Product { get; set; } = null!;
    public Dish Dish { get; set; } = null!;
}
