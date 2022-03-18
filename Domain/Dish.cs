namespace Domain;

public class Dish : IItem
{
    public decimal Cost { get; set; }
    public string Name { get; set; }
    public ushort Sale { get; set; }
    public string Description { get; set; }
}
