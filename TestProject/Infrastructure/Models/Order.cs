namespace TestProject.Infrastructure.Models;

public class Order : BaseEntity
{
    public decimal Sum { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
}