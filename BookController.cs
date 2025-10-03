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
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Кобзар", Author = "Тарас Шевченко", Genre = "Поезія", Price = 100 },
                new Book { Id = 2, Title = "1984", Author = "Джордж Орвелл", Genre = "Антиутопія", Price = 120 }
            };
            return books ?? new List<Book>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }
    }
}
