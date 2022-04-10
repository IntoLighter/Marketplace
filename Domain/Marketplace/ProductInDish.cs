namespace Domain.Marketplace;

public class ProductInDish
{
    public int Id { get; set; }
    public Product Product { get; set; } = null!;
    public Dish Dish { get; set; } = null!;
}
