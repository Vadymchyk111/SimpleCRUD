using Microsoft.EntityFrameworkCore;
using TestProject.Domain.Store;
using TestProject.Infrastructure.Models;

namespace TestProject.Infrastructure.Repositories.Store;

public class BookRepository : IBookRepository
{
    private readonly DatabaseContext _databaseContext;

    public BookRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    
    public async Task<BookDomain?> GetBookByTitleAsync(string title)
    {
        Book? book = await _databaseContext.Set<Book>().FirstOrDefaultAsync(x => x.Title == title);
        return book is null ? null : MapToDomain(book);

    }
    public async Task<BookDomain?> GetBookByIdAsync(Guid id)
    {
        Book? book = await _databaseContext.Set<Book>().FirstOrDefaultAsync(x => x.Id == id);
        return book is null ? null : MapToDomain(book);

    }

    private static BookDomain MapToDomain(Book book)
    {
        return new BookDomain(book.Id, book.Title, book.Description, book.Genre, book.Price);
    }

    public async Task AddBookAsync(BookDomain bookDomain)
    {
        await _databaseContext.AddAsync(new Book
        {
            Description = bookDomain.Description,
            Title = bookDomain.Title,
            Genre = bookDomain.Genre,
            Price = bookDomain.Price
        });
        await _databaseContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(BookDomain bookDomain)
    {
        Book? book = await _databaseContext.Set<Book>().FirstOrDefaultAsync(x => x.Id == bookDomain.Id);
        if (book is null) {
            //Log error
            return;
        }

        book.Title = bookDomain.Title;
        book.Genre = bookDomain.Genre;
        book.Description = bookDomain.Description;
        book.Price = bookDomain.Price;
        
        _databaseContext.Update(book);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        Book? book = await _databaseContext.Set<Book>().FirstOrDefaultAsync(x => x.Id == id);
        if (book is null) {
            //Log error
            return;
        }
        
        _databaseContext.Remove(book);
        await _databaseContext.SaveChangesAsync();
    }
}