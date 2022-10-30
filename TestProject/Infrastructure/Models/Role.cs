namespace TestProject.Infrastructure.Models;

public class Role : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<User> Users { get; set; } = new List<User>();
}