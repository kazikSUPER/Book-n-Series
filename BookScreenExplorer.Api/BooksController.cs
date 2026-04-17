using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookScreenExplorer.Infrastructure.Data;
using BookScreenExplorer.Infrastructure.Entities;

namespace BookScreenExplorer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BooksController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/books
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _context.Books
            .Take(10)
            .ToListAsync();

        return Ok(books);
    }

    // GET: api/books/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await _context.Books
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
            return NotFound(new { message = "Book not found" });

        return Ok(book);
    }
}
