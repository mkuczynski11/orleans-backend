using Auctions.Infrastructure.Data.Models;

namespace Auctions.Infrastructure.Data.DTOs;

public record GetUserDetailsDto
{
    public GetUserDetailsDto(User user)
    {
        Id = user.Id;
        Email = user.Email;
        Username = user.Username;
        OwnedAuctions = user.OwnedAuctions.Select(auction => new AuctionDto(auction.Id, auction.Owner.Username, auction.Item.Name, auction.Item.Category.Name)).ToList();
        BidAuctions = user.AuctionBids.Select(auctionBid => new AuctionDto(auctionBid.Auction.Id, auctionBid.Auction.Owner.Username, auctionBid.Auction.Item.Name, auctionBid.Auction.Item.Category.Name)).ToList();
    }
    public Guid Id { get; }
    public string Email { get; }
    public string Username { get; }
    public List<AuctionDto> OwnedAuctions { get; set; }
    public List<AuctionDto> BidAuctions { get; set; }
    public record AuctionDto(Guid Id, string Owner, String ItemName, string CategoryName);
}