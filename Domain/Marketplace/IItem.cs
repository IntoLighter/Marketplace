namespace Domain.Marketplace;

public interface IItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUri { get; set; }
    public int Weight { get; set; }
}
