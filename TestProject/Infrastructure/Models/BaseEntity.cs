namespace TestProject.Infrastructure.Models;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime TimeOfCreation { get; set; } = DateTime.Now;
}