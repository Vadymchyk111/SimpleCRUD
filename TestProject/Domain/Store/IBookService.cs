namespace TestProject.Domain.Store;

public interface IBookService
{
    Task AddIfNew(BookDomain bookDomain);
}