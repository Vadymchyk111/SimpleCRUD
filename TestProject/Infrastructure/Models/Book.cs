namespace TestProject.Infrastructure.Models;

public class Book : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public decimal Price { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}