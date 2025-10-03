namespace OnlineBookShop.Components.Pages.Models;

public partial class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; } 
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; } = string.Empty;
    public string CoverImage { get; set; } = string.Empty;
}


public class BookService
{
    public List<Book> GetTopBooks2025()
    {
        return new List<Book>
        {
            new Book { Id = 1, Title = "Книга 1", Author = "Автор 1", Genre = "Детектив", CoverImage = "book1.jpg", Price = 300 },
            new Book { Id = 2, Title = "Книга 2", Author = "Автор 2", Genre = "Психологія", CoverImage = "book1.jpg", Price = 250 },
            new Book { Id = 3, Title = "Книга 3", Author = "Автор 3", Genre = "Детектив", CoverImage = "book1.jpg", Price = 289 },
            new Book { Id = 4, Title = "Книга 4", Author = "Автор 4", Genre = "Психологія", CoverImage = "book1.jpg", Price = 365 }
        };
    }

    public List<Book> GetBestDetectives()
    {
        return GetTopBooks2025().Where(b => b.Genre == "Детектив").ToList();
    }

    public List<Book> GetPsychologyBooks()
    {
        return GetTopBooks2025().Where(b => b.Genre == "Психологія").ToList();
    }
}
