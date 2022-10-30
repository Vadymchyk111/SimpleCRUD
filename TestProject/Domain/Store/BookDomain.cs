namespace TestProject.Domain.Store;

public class BookDomain
{
    public Guid Id { get; }
    public string Title { get; }
    public string Description { get; }
    public string Genre { get; }
    public decimal Price { get; }

    public BookDomain(Guid id,string title, string description, string genre, decimal price)
    {
        Id = id;
        Title = title;
        Description = description;
        Genre = genre;
        Price = price;
    }
}