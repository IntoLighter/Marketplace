namespace Domain.Marketplace;

public class Dish : IItem
{
    public List<ProductInDish> Products { get; set; } = null!;
    public DishCategory Category { get; set; }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUri { get; set; } = string.Empty;
    public int Weight { get; set; }
}
