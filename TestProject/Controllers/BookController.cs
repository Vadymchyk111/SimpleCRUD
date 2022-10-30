using Microsoft.AspNetCore.Mvc;
using TestProject.Domain.Store;
using TestProject.Dto.Store;

namespace TestProject.Controllers;

[ApiController]
[Route("api/book")]
public class BookController
{
    private IBookService _bookService;
    private IBookRepository _bookRepository;

    public BookController(IBookService bookService,IBookRepository bookRepository)
    {
        _bookService = bookService;
        _bookRepository = bookRepository;
    }

    [HttpGet()]
    public async Task<BookDto> GetBook([FromQuery] Guid id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);
        return new BookDto
        {
            Id = book?.Id,
            Title = book?.Title,
            Genre = book?.Genre,
            Description = book?.Description,
            Price = book?.Price ?? decimal.Zero
        };
    }
    [HttpPost]
    public async Task AddBookIfNew([FromBody] BookDto bookDto)
    {
        await _bookService.AddIfNew(new BookDomain(
            bookDto.Id ?? Guid.Empty, 
            bookDto.Title ?? string.Empty, 
            bookDto.Description ?? string.Empty, 
            bookDto.Genre ?? string.Empty,
            bookDto.Price));
    }

    [HttpPut]
    public async Task UpdateBook([FromBody] BookDto bookDto)
    {
        await _bookRepository.UpdateAsync(new BookDomain(
            bookDto.Id ?? Guid.Empty, 
            bookDto.Title ?? string.Empty, 
            bookDto.Description ?? string.Empty, 
            bookDto.Genre ?? string.Empty,
            bookDto.Price));
    }
    
    [HttpDelete]
    public async Task DeleteBook([FromQuery] Guid id)
    {
        await _bookRepository.DeleteAsync(id);
    }
}