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
    public DbSet<AuctionBid> Bids => Set<AuctionBid>();
    public DbSet<Auction> Auctions => Set<Auction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(Seed.Categories);
        base.OnModelCreating(modelBuilder);
    }
}
