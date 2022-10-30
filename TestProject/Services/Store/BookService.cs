using TestProject.Domain.Store;

namespace TestProject.Services.Store;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task AddIfNew(BookDomain bookDomain)
    {
        if (await _bookRepository.GetBookByTitleAsync(bookDomain.Title) is null)
        {
            await _bookRepository.AddBookAsync(bookDomain);
        }
    }
}