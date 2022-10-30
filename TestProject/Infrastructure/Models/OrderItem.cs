namespace TestProject.Infrastructure.Models;

public class OrderItem : BaseEntity
{
    public Order Order { get; set; } = null!;
    public ICollection<Book> Books { get; set; } = new List<Book>();
}