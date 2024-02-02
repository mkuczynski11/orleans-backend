namespace Auctions.Infrastructure.Data.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public ICollection<AuctionBid> AuctionBids { get; set; } = new List<AuctionBid>();
        public ICollection<Auction> OwnedAuctions { get; set; } = new List<Auction>();
    }
}
