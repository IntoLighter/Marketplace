namespace Domain.Marketplace;

public class Product : IItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUri { get; set; } = string.Empty;
    public int Weight { get; set; }
}