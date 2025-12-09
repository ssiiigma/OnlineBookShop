using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookShop.Components.Pages.Models;

[Table("books", Schema = "dbo")]
public partial class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Author Author { get; set; }
    [Column("Genre")]
    public string Genre { get; set; } 
    public decimal Price { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("imageUrl")]
    public string CoverImage { get; set; } = string.Empty;
}

public class Author
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;

    public ICollection<Book> Books { get; set; }
}


public class BookService
{
    public List<Book> GetTopBooks2025()
    {
        return new List<Book>();
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
