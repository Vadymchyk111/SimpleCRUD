using Microsoft.EntityFrameworkCore;
using TestProject.Infrastructure.Models;

namespace TestProject.Infrastructure;

public class DatabaseContext : DbContext
{
    public string ConnectionString { get; set; }
    
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;

    public DatabaseContext(string connectionString = "Host=localhost;Port=5432;Database=test.db;username=password=;")
    {
        ConnectionString = connectionString;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasIndex(u => u.Title).IsUnique();
    }

    public async Task InitializeDatabaseAsync(string connectionString)
    {
        ConnectionString = connectionString;
        await Database.MigrateAsync();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
    }
    
}
