namespace TestProject.Domain.Store;

public interface IBookRepository
{
    Task<BookDomain?> GetBookByTitleAsync(string title);
    Task<BookDomain?> GetBookByIdAsync(Guid id);
    Task AddBookAsync(BookDomain bookDomain);
    Task UpdateAsync(BookDomain bookDomain);
    Task DeleteAsync(Guid id);
}