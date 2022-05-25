using WebApplication1.Data.Models;

namespace WebApplication1.Data;

using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

public class EducationContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Affiliation> Affiliations { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder); optionsBuilder.UseNpgsql(@"Host=localhost;Database=education;Username=education;Password=password")
            .UseSnakeCaseNamingConvention()
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().Property(p => p.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Book>().Property(p => p.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Shop>().Property(p => p.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Author>().HasMany(au => au.Books).WithMany(af => af.Authors);
        modelBuilder.Entity<Shop>().HasMany(ar => ar.Authors).WithMany(au => au.Shops);

    }
    

}
