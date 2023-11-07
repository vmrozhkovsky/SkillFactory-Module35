using Microsoft.EntityFrameworkCore;

namespace EF;

public class AppContext : DbContext
{
    // Объекты таблицы Users
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Book { get; set; }
    public AppContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=EF;Trusted_Connection=True;TrustServerCertificate=true;");
    }
}