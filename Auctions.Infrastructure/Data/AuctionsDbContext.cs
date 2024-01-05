using Microsoft.EntityFrameworkCore;
using Auctions.Infrastructure.Data.Models;

namespace Auctions.Infrastructure.Data;
public class AuctionsDbContext : DbContext
{
    protected AuctionsDbContext()
    {
    }

    public AuctionsDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(Seed.Categories);
        base.OnModelCreating(modelBuilder);
    }
}
