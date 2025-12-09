using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Components.Pages.Models;

namespace OnlineBookShop
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public BooksController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            var books = new List<Book>();
            return books ?? new List<Book>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.books.FindAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            _context.books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }
    }
}
