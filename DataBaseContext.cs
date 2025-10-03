using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Components.Pages.Models;

namespace OnlineBookShop;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().ToTable("Books");
        modelBuilder.Entity<Book>()
            .Property(p => p.Price)
            .HasPrecision(18, 2); // decimal(18,2)
    }

    
}