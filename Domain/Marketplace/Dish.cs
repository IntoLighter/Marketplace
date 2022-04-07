namespace Domain.Marketplace;

public class Dish : IItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUri { get; set; } = string.Empty;
    public int Weight { get; set; }
    public List<Product> Products { get; set; } = new();
}
